using AuxLabs.Twitch.Chat.Api;
using AuxLabs.Twitch.Chat.Entities;
using AuxLabs.Twitch.Chat.Models;
using AuxLabs.Twitch.Rest;
using AuxLabs.Twitch.Rest.Models;
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
        public bool IsReadOnly { get; private set; } = true;   

        public ChatSelfUser MyUser { get; internal set; }
        public IReadOnlyCollection<ChatSimpleChannel> Channels => _channels.ToReadOnlyCollection();

        public TwitchChatClient(TwitchChatConfig config = null)
            : this(TwitchConstants.ChatSecureWebSocketUrl, config) { }
        public TwitchChatClient(string url, TwitchChatConfig config = null)
        {
            _channels = new ConcurrentDictionary<string, ChatSimpleChannel>();
            _channelNameMap = new ConcurrentDictionary<string, string>();

            config ??= new TwitchChatConfig();
            UseBufferedResponses = config.UseBufferedResponses;
            MessageCacheSize = config.MessageCacheSize;

            Rest = new TwitchRestClient(config.RestConfig ??= new TwitchRestConfig());
            IRC = new TwitchChatApiClient(url, config);

            //IRC.PayloadReceived += (p, s) => HandleEventAsync(p).ConfigureAwait(false);
            IRC.Connected += () => _connectedEvent.InvokeAsync().ConfigureAwait(false);
            IRC.Disconnected += ex => _disconnectedEvent.InvokeAsync(ex).ConfigureAwait(false);
            IRC.UnknownEventReceived += payload => _unknownEventReceivedEvent.InvokeAsync(payload).ConfigureAwait(false);
            IRC.Reconnect += () => _reconnectEvent.InvokeAsync().ConfigureAwait(false);

            IRC.GlobalUserStateReceived += OnGlobalUserState;
            IRC.ChatCleared += OnChatCleared;
            IRC.MessageCleared += OnMessageCleared;
            IRC.ChannelJoined += OnChannelJoined;
            IRC.ChannelLeft += OnChannelLeft;
            IRC.UserStateReceived += OnUserState;
            IRC.RoomStateReceived += OnRoomState;
            IRC.MessageReceived += OnMessage;
            IRC.WhisperReceived += OnWhisper;
            IRC.UserNoticeReceived += OnUserNotice;
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
            if (Identity != null)   // Rest is authorized as a user
            {
                if (!Identity.Scopes.Contains("chat:read")) throw new MissingScopeException("chat:read");
                if (Identity.Scopes.Contains("chat:edit")) IsReadOnly = false;
                IRC.WithIdentity(Identity.UserName, Identity.AccessToken);
            } else  // Apps and anonymous authorization
            {
                _anonymousName = TwitchConstants.AnonymousNamePrefix + RandomNumberGenerator.GetInt32(9999);
                IRC.WithIdentity(_anonymousName, _anonymousName);
            }
            
            return IRC.RunAsync();
        }

        #region Requests

        public Task<ChatChannel> JoinMyChannelAsync(CancellationToken? cancelToken = null)
            => JoinChannelAsync(Identity.UserName, cancelToken);
        public Task<ChatChannel> JoinChannelAsync(string channelName, CancellationToken? cancelToken = null)
        {
            var tcs = new TaskCompletionSource<ChatChannel>();
            var ct = cancelToken ?? new CancellationTokenSource(TimeSpan.FromMilliseconds(500)).Token;
            ct.Register(() => tcs.TrySetCanceled(), false);

            if (!UseBufferedResponses)
                tcs.SetResult(null);
            else 
            {
                Func<ChatChannel, ChatChannel, Task> waitFor = null;
                ChannelStateUpdated += waitFor = (_, after) =>
                {
                    if (after.Name != channelName)
                        return Task.CompletedTask;

                    tcs.SetResult(after);
                    ChannelStateUpdated -= waitFor;
                    return Task.CompletedTask;
                };
            }

            IRC.SendJoin(channelName);
            return tcs.Task;
        }

        public IAsyncEnumerable<ChatChannel> JoinChannelsAsync(params string[] channelNames)
            => JoinChannelsAsync(channelNames);
        public async IAsyncEnumerable<ChatChannel> JoinChannelsAsync(string[] channelNames, CancellationToken? cancelToken = null)
        {
            foreach (var channelName in channelNames)
                yield return await JoinChannelAsync(channelName, cancelToken).ConfigureAwait(false);
        }

        public Task<ChatSimpleChannel> LeaveChannelAsync(string channelName)
            => LeaveChannelAsync(channelName);
        public Task<ChatSimpleChannel> LeaveChannelAsync(string channelName, CancellationToken? cancelToken = null)
        {
            var tcs = new TaskCompletionSource<ChatSimpleChannel>();
            var ct = cancelToken ?? new CancellationTokenSource(TimeSpan.FromMilliseconds(500)).Token;
            ct.Register(() => tcs.TrySetCanceled(), false);

            if (!UseBufferedResponses)
                tcs.SetResult(null);
            else
            {
                Func<ChatSimpleChannel, Task> waitFor = null;
                ChannelLeft += waitFor = channel =>
                {
                    if (channel.Name != channelName)
                        return Task.CompletedTask;

                    tcs.SetResult(channel);
                    ChannelLeft -= waitFor;
                    return Task.CompletedTask;
                };
            }

            IRC.SendPart(channelName);
            return tcs.Task;
        }

        public IAsyncEnumerable<ChatSimpleChannel> LeaveChannelsAsync(params string[] channelNames)
            => LeaveChannelsAsync(channelNames);
        public async IAsyncEnumerable<ChatSimpleChannel> LeaveChannelsAsync(string[] channelNames, CancellationToken? cancelToken = null)
        {
            foreach (var channelName in channelNames)
                yield return await LeaveChannelAsync(channelName, cancelToken).ConfigureAwait(false);
        }

        public Task<string> SendMessageAsync(string channelName, string text, string replyMessageId = null, CancellationToken? cancelToken = null)
        {
            if (IsReadOnly) throw new MissingScopeException("chat:edit");

            var tcs = new TaskCompletionSource<string>();
            var ct = cancelToken ?? new CancellationTokenSource(TimeSpan.FromMilliseconds(500)).Token;
            ct.Register(() => tcs.TrySetCanceled(), false);

            if (!UseBufferedResponses)
                tcs.SetResult(null);
            else
            {
                Func<ChatChannelSelfUser, ChatChannelSelfUser, string, Task> waitFor = null;
                UserStateUpdated += waitFor = (_, after, msgId) =>
                {
                    if (after.Channel.Name != channelName)
                        return Task.CompletedTask;

                    tcs.SetResult(msgId);
                    UserStateUpdated -= waitFor;
                    return Task.CompletedTask;
                };

                Action<NoticeEventArgs> errorFor = null;
                IRC.NoticeReceived += errorFor = args =>
                {
                    if (args.ChannelName != channelName) return;
                    IRC.NoticeReceived -= errorFor;
                    tcs.TrySetException(new TwitchChatException(args));
                };
            }

            IRC.SendMessage(channelName, text, replyMessageId);
            return tcs.Task;
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
        #region Handle Events

        private void OnGlobalUserState(GlobalUserStateTags args)
        {
            MyUser = ChatSelfUser.Create(this, args);
            _loggedInEvent.InvokeAsync(MyUser).ConfigureAwait(false);
        }

        private void OnChatCleared(ClearChatEventArgs args)
        {
            var channel = GetChannel(args.Tags.ChannelId);
            var user = channel.GetUser(args.Tags.TargetUserId);

            if (user == null) // If no user is provided, all of chat was cleared
            {
                var oldCache = channel.ClearMessages();
                _chatClearedEvent.InvokeAsync((ChatChannel)channel, oldCache).ConfigureAwait(false);
            }
            else
            {
                if (args.Tags.BanDuration == null)
                    channel.RemoveUser(user.Id);
                _userBannedEvent.InvokeAsync((ChatChannel)channel, user, args.Tags.BanDuration).ConfigureAwait(false);
            }
        }

        private void OnMessageCleared(ClearMessageEventArgs args)
        {
            var channel = GetChannelByName(args.ChannelName);
            ChatSimpleMessage msg = channel.RemoveMessage(args.Tags.TargetMessageId);
            if (msg == null)
            {
                var author = channel.GetUser(args.Tags.UserName);
                msg = ChatSimpleMessage.Create(this, args, channel, author);
                channel.RemoveMessage(msg.Id);
            }

            _messageDeletedEvent.InvokeAsync(msg).ConfigureAwait(false);
        }

        private void OnChannelJoined(MembershipEventArgs args)
        {
            if (args.UserName == CurrentName)
            {
                _channelJoinedEvent.InvokeAsync(args.ChannelName).ConfigureAwait(false);
            }
            else
            {
                var channel = GetChannelByName(args.ChannelName);
                _userJoinedChannelEvent.InvokeAsync(channel, args.UserName).ConfigureAwait(false);
            }
        }

        private void OnChannelLeft(MembershipEventArgs args)
        {
            if (args.UserName == CurrentName)
            {
                var channel = RemoveChannelByName(args.ChannelName);
                _channelLeftEvent.InvokeAsync(channel).ConfigureAwait(false);
            }
            else
            {
                var channel = GetChannelByName(args.ChannelName);
                _userLeftChannelEvent.InvokeAsync(channel, args.UserName).ConfigureAwait(false);
            }
        }

        private void OnUserState(UserStateEventArgs args)
        {
            var channel = GetChannelByName(args.ChannelName);

            ChatSimpleUser beforeUser = null;
            if (channel != null)
                beforeUser = channel.GetUser(args.Tags.UserId);

            var user = ChatChannelSelfUser.Create(this, args);
            user.Channel = channel;

            channel?.AddUser(user);
            _userStateUpdatedEvent.InvokeAsync(beforeUser as ChatChannelSelfUser, user, args.Tags.MessageId).ConfigureAwait(false);
        }

        private void OnRoomState(RoomStateEventArgs args)
        {
            var beforeChannel = GetChannel(args.Tags.ChannelId);
            var channel = ChatChannel.Create(this, args);

            AddChannel(channel);
            _channelStateUpdated.InvokeAsync(beforeChannel as ChatChannel, channel).ConfigureAwait(false);
        }

        private void OnMessage(MessageEventArgs args)
        {
            var channel = GetChannel(args.Tags.ChannelId);
            if (channel == null)
            {
                channel = ChatSimpleChannel.Create(this, args);
                AddChannel(channel);
            }

            var author = (ChatChannelUser)channel.GetUser(args.Tags.AuthorId);
            author ??= ChatChannelUser.Create(this, args);

            var replyAuthor = channel.GetUser(args.Tags.ReplyAuthorId);
            replyAuthor ??= ChatSimpleUser.Create(this, args, true);

            var message = ChatMessage.Create(this, args, channel, author, replyAuthor);

            channel.AddUser(author);
            channel.AddMessage(message);
            _messageReceivedEvent.InvokeAsync(message).ConfigureAwait(false);
        }

        private void OnWhisper(WhisperEventArgs args)
        {
            var author = ChatUser.Create(this, args);
            var message = ChatWhisperMessage.Create(this, args, author);

            _whisperReceivedEvent.InvokeAsync(message).ConfigureAwait(false);
        }

        private void OnUserNotice(UserNoticeEventArgs args)
        {
            var channel = GetChannel(args.Tags.ChannelId);
            var author = channel.GetUser(args.Tags.AuthorId);
            //channel.Update(userNoticeArgs);

            switch (args.Tags)
            {
                case BitsBadgeTierTags bitsBadgeTierTags:
                    break;

                case RaidTags raidTags:
                    {
                        var raider = ChatRaidUser.Create(this, raidTags);
                        _channelRaidedEvent.InvokeAsync(raider, channel, raidTags.RaiderViewerCount).ConfigureAwait(false);
                    }
                    break;

                case RitualTags ritualTags: // Forward this through MessageReceived
                    break;

                case SubscriptionGiftTags subGiftTags:
                    break;

                case SubscriptionGiftUpgradeTags subGiftUpgradeTags:
                    break;

                case SubscriptionGiftUpgradeAnonymousTags subGiftAnonUpgradeTags:
                    break;

                case SubscriptionTags subTags:
                    {
                        // VS is trying to force usage of ChatSimpleMessage here but won't allow overriding the inherited member???
                        // Throwaway bool as a temp fix
                        var subMessage = ChatSubscriptionMessage.Create(this, args, channel, (ChatChannelUser)author, false);
                        _messageReceivedEvent.InvokeAsync(subMessage).ConfigureAwait(false);
                    }
                    break;
            }
        }

        #endregion
    }
}
