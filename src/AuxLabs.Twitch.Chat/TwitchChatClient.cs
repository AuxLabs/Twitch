using AuxLabs.Twitch.Chat.Api;
using AuxLabs.Twitch.Chat.Entities;
using AuxLabs.Twitch.Chat.Models;
using AuxLabs.Twitch.Rest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Chat
{
    public partial class TwitchChatClient
    {
        private readonly ConcurrentDictionary<string, ChatSimpleChannel> _channels;
        private readonly ConcurrentDictionary<string, string> _channelNameMap;
        private string _anonymousName = null;
        private bool _disposed = false;

        protected TwitchChatApiClient IRC { get; }
        public TwitchRestClient Rest { get; }

        public string CurrentName => Identity?.UserName ?? _anonymousName;
        public UserIdentity Identity => Rest.Identity as UserIdentity;
        public bool CommandsRequested => IRC.CommandsRequested;
        public bool TagsRequested => IRC.TagsRequested;
        public bool ThrowOnUnknownEvent => IRC.ThrowOnUnknownEvent;

        public bool UseBufferedResponses { get; }
        public int MessageCacheSize { get; }
        public bool CanSendMessages { get; private set; } = false;   

        public ChatSelfUser MyUser { get; internal set; }
        public IReadOnlyCollection<ChatSimpleChannel> Channels => _channels.ToReadOnlyCollection();

        public TwitchChatClient(TwitchChatConfig config = null)
            : this(TwitchConstants.ChatSecureWebSocketUrl, config) { }
        public TwitchChatClient(string url, TwitchChatConfig config = null)
        {
            _channels = new ConcurrentDictionary<string, ChatSimpleChannel>();
            _channelNameMap = new ConcurrentDictionary<string, string>();

            config ??= new TwitchChatConfig();
            config.ShouldHandleEvents = false;
            UseBufferedResponses = config.UseBufferedResponses;
            MessageCacheSize = config.MessageCacheSize;

            Rest = new TwitchRestClient(config.RestConfig ??= new TwitchRestConfig());
            IRC = new TwitchChatApiClient(url, config);

            IRC.PayloadReceived += (p, s) => HandleEventAsync(p).ConfigureAwait(false);
            IRC.Connected += () => _connectedEvent.InvokeAsync().ConfigureAwait(false);
            IRC.Disconnected += (ex) => _disconnectedEvent.InvokeAsync(ex).ConfigureAwait(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    IRC.Dispose();
                    Rest.Dispose();
                }

                _disposed = true;
            }
        }

        public Task ValidateAsync() => Rest.ValidateAsync();

        public Task ValidateAsync(string token, string refreshToken = null)
            => Rest.ValidateAsync(token, refreshToken);

        public Task RunAsync()
        {
            if (Identity != null)       // Rest is authorized as a user
            {
                if (!Identity.Scopes.Contains("chat:read")) throw new MissingScopeException("chat:read");
                if (Identity.Scopes.Contains("chat:edit")) CanSendMessages = true;
                IRC.WithIdentity(Identity.UserName, Identity.AccessToken);
            } else                      // Apps will authorize as anonymous
            {
                _anonymousName = TwitchConstants.AnonymousNamePrefix + RandomNumberGenerator.GetInt32(9999);
                IRC.WithIdentity(_anonymousName, _anonymousName);
            }
            
            return IRC.RunAsync();
        }

        #region Requests

        // UserState, RoomState, and Names should be cached rather than returned to the user
        public Task<ChatChannel> JoinMyChannelAsync(CancellationToken? cancelToken = null)
            => JoinChannelAsync(Identity.UserName, cancelToken);
        public Task<ChatChannel> JoinChannelAsync(string channelName, CancellationToken? cancelToken = null)
        {
            var tcs = new TaskCompletionSource<ChatChannel>();

            if (!UseBufferedResponses)
                tcs.SetResult(null);
            else 
            {
                Func<ChatChannel, ChatChannel, Task> waitFor = null;
                ChannelStateUpdated += waitFor = (_, after) =>
                {
                    tcs.SetResult(after);
                    ChannelStateUpdated -= waitFor;
                    return Task.CompletedTask;
                };
            }

            IRC.SendJoinAsync(new[] { channelName }, cancelToken);
            return tcs.Task;
        }

        public IAsyncEnumerable<ChatChannel> JoinChannelsAsync(params string[] channelNames)
            => JoinChannelsAsync(channelNames);
        public async IAsyncEnumerable<ChatChannel> JoinChannelsAsync(string[] channelNames, CancellationToken? cancelToken = null)
        {
            foreach (var channelName in channelNames)
                yield return await JoinChannelAsync(channelName, cancelToken).ConfigureAwait(false);
        }

        public Task LeaveChannelsAsync(params string[] channelNames)
            => IRC.SendPartAsync(channelNames);
        public Task LeaveChannelsAsync(string[] channelNames, CancellationToken? cancelToken = null)
            => IRC.SendPartAsync(channelNames, cancelToken);

        public async Task SendMessageAsync(string channelName, string text, string replyMessageId = null)
        {
            if (!CanSendMessages) throw new MissingScopeException("chat:edit");

            await IRC.SendMessageAsync(channelName, text, replyMessageId);
        }

        #endregion
        #region Cache

        /// <summary> Get a channel from the cache </summary>
        public ChatSimpleChannel GetChannel(string id)
        {
            if (id == null) return null;
            if (_channels.TryGetValue(id, out var channel))
                return channel;
            return null;
        }
        public ChatSimpleChannel GetChannelByName(string name)
        {
            if (name == null) return null;
            if (_channelNameMap.TryGetValue(name, out var id))
                return GetChannel(id);
            return null;
        }
        internal void AddChannel(ChatSimpleChannel channel)
        {
            _channels[channel.Id] = channel;
            _channelNameMap[channel.Name] = channel.Id;
        }
        internal ChatSimpleChannel RemoveChannel(string id)
        {
            if (id == null) return null;
            if (_channels.TryRemove(id, out var channel))
            {
                _channelNameMap.Remove(channel.Name, out _);
                return channel;
            }
            return null;
        }
        internal ChatSimpleChannel RemoveChannelByName(string name)
        {
            if (name == null) return null;
            if (_channelNameMap.TryGetValue(name, out var id))
                return RemoveChannel(id);
            return null;
        }

        #endregion

        protected async Task HandleEventAsync(IrcPayload payload)
        {
            switch (payload.Command)
            {
                case IrcCommand.Reconnect:
                    await _reconnectEvent.InvokeAsync();
                    break;

                case IrcCommand.GlobalUserState:
                    MyUser = ChatSelfUser.Create(this, (GlobalUserStateTags)payload.Tags);
                    await _loggedInEvent.InvokeAsync(MyUser);
                    break;

                case IrcCommand.ClearChat:
                    var clearChatArgs = ClearChatEventArgs.Create(payload);

                    var channel = GetChannel(clearChatArgs.Tags.ChannelId);
                    var user = channel.GetUser(clearChatArgs.Tags.TargetUserId);

                    if (user == null) // If no user is provided, all of chat was cleared
                    {
                        var oldCache = channel.ClearMessages();
                        await _chatClearedEvent.InvokeAsync((ChatChannel)channel, oldCache);
                    } else
                    {
                        if (clearChatArgs.Tags.BanDuration == null)
                            channel.RemoveUser(user.Id);
                        await _userBannedEvent.InvokeAsync((ChatChannel)channel, user, clearChatArgs.Tags.BanDuration);
                    }
                    break;

                case IrcCommand.ClearMessage:
                    var clearMsgArgs = ClearMessageEventArgs.Create(payload);

                    channel = GetChannelByName(clearMsgArgs.ChannelName);
                    ChatSimpleMessage msg = channel.RemoveMessage(clearMsgArgs.Tags.TargetMessageId);
                    if (msg == null)
                    {
                        user = channel.GetUserByName(clearMsgArgs.Tags.UserName);
                        msg = ChatSimpleMessage.Create(this, clearMsgArgs, channel, user);
                        channel.RemoveMessage(msg.Id);
                    }

                    await _messageDeletedEvent.InvokeAsync(msg);
                    break;

                case IrcCommand.Join:
                    var membershipArgs = MembershipEventArgs.Create(payload);
                    if (membershipArgs.UserName == CurrentName)
                    {
                        await _channelJoinedEvent.InvokeAsync(membershipArgs.ChannelName);
                    } else
                    {
                        channel = GetChannelByName(membershipArgs.ChannelName);
                        await _userJoinedChannelEvent.InvokeAsync(channel, membershipArgs.UserName);
                    }

                    break;

                case IrcCommand.Part:
                    membershipArgs = MembershipEventArgs.Create(payload);
                    if (membershipArgs.UserName == CurrentName)
                    {
                        channel = RemoveChannelByName(membershipArgs.ChannelName);
                        await _channelLeftEvent.InvokeAsync(channel);
                    } else
                    {
                        channel = GetChannelByName(membershipArgs.ChannelName);
                        await _userLeftChannelEvent.InvokeAsync(channel, membershipArgs.UserName);
                    }
                    break;

                case IrcCommand.Whisper:
                    break;

                case IrcCommand.Message:
                    var messageArgs = MessageEventArgs.Create(payload);

                    channel = GetChannel(messageArgs.Tags.ChannelId);
                    if (channel == null)
                    {
                        channel = ChatSimpleChannel.Create(this, messageArgs);
                        AddChannel(channel);
                    }

                    var author = (ChatChannelUser)channel.GetUser(messageArgs.Tags.AuthorId);
                    author ??= ChatChannelUser.Create(this, messageArgs);

                    var replyAuthor = channel.GetUser(messageArgs.Tags.ReplyAuthorId);
                    replyAuthor ??= ChatSimpleUser.Create(this, messageArgs, true);

                    var message = ChatMessage.Create(this, messageArgs, channel, author, replyAuthor);

                    channel.AddUser(author);
                    channel.AddMessage(message);
                    await _messageReceivedEvent.InvokeAsync(message);
                    break;

                case IrcCommand.RoomState:
                    var roomStateArgs = RoomStateEventArgs.Create(payload);

                    var beforeChannel = GetChannel(roomStateArgs.Tags.ChannelId);
                    channel = ChatChannel.Create(this, roomStateArgs);

                    AddChannel(channel);
                    await _channelStateUpdated.InvokeAsync(beforeChannel as ChatChannel, (ChatChannel)channel);
                    break;

                case IrcCommand.UserState:
                    var userStateArgs = UserStateEventArgs.Create(payload);

                    channel = GetChannelByName(userStateArgs.ChannelName);

                    ChatSimpleUser beforeUser = null;
                    if (channel != null)
                        beforeUser = channel.GetUser(userStateArgs.Tags.UserId);

                    user = ChatChannelSelfUser.Create(this, userStateArgs);
                    ((ChatChannelSelfUser)user).Channel = channel;

                    channel?.AddUser(user);
                    await _userStateUpdatedEvent.InvokeAsync(beforeUser as ChatChannelSelfUser, (ChatChannelSelfUser)user, userStateArgs.Tags.MessageId);
                    break;

                case IrcCommand.UserNotice:
                    var userNoticeArgs = UserNoticeEventArgs.Create(payload);
                    switch (userNoticeArgs.Tags)
                    {
                        case BitsBadgeTierTags bitsBadgeTierTags:
                            break;

                        case RaidTags raidTags:
                            break;

                        case RitualTags ritualTags:
                            break;

                        case SubscriptionGiftTags subscriptionGiftTags:
                            break;

                        case SubscriptionGiftUpgradeTags subscriptionGiftUpgradeTags:
                            break;

                        case SubscriptionGiftUpgradeAnonymousTags subscriptionGiftAnonUpgradeTags:
                            break;

                        case SubscriptionTags subscriptionTags:
                            break;

                        default:
                            break;
                    }
                    break;

                case IrcCommand.Notice:
                    break;

                case IrcCommand.Ping:
                    break;
                case IrcCommand.NamesList:
                    break;
                case IrcCommand.NamesEnd:
                    break;

                case IrcCommand.RPL_Welcome:        // Ignorable messages sent after authentication
                case IrcCommand.RPL_YourHost:
                case IrcCommand.RPL_Created:
                case IrcCommand.RPL_MyInfo:
                case IrcCommand.RPL_MotdStart:
                case IrcCommand.RPL_Motd:
                case IrcCommand.RPL_MotdEnd:
                case IrcCommand.CapabilityAcknowledge:
                    break;

                case IrcCommand.CapabilityDenied:
                    throw new TwitchException($"Capabilities denied: {string.Join(' ', payload.Parameters)}");
                default:
                    await _unhandledCommandEvent.InvokeAsync(payload);
                    if (ThrowOnUnknownEvent)
                        throw new TwitchException($"An unhandled event of type `{payload.CommandRaw}` was received");
                    break;
            }
        }
    }
}
