﻿using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using RoomState = AuxLabs.Twitch.Chat.Models.RoomStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatSimpleChannel : ChatEntity<string>
    {
        private readonly ConcurrentDictionary<string, ChatSimpleUser> _users;
        private readonly ConcurrentDictionary<string, string> _userNameMap;
        private readonly MessageCache _messages;

        public IReadOnlyCollection<ChatChannelUser> Users => _users.Select(x => (ChatChannelUser)x.Value).ToArray();

        /// <summary> The channel's name </summary>
        public string Name { get; internal set; }

        internal ChatSimpleChannel(TwitchChatClient twitch, string id)
            : base(twitch, id) 
        {
            _users = new ConcurrentDictionary<string, ChatSimpleUser>();
            _userNameMap = new ConcurrentDictionary<string, string>();
            _messages = new MessageCache(twitch.MessageCacheSize);
        }

        internal static ChatSimpleChannel Create(TwitchChatClient twitch, RoomState model)
        {
            var entity = new ChatSimpleChannel(twitch, model.Tags.ChannelId);
            entity.Update(model);
            return entity;
        }
        internal static ChatSimpleChannel Create(TwitchChatClient twitch, Message model)
        {
            var entity = new ChatSimpleChannel(twitch, model.Tags.ChannelId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(RoomState model)
        {
            Name = model.ChannelName;
        }
        internal virtual void Update(Message model)
        {
            Name = model.ChannelName;
        }

        public override string ToString()
            => $"{Name} ({Id})";

        // Cache Methods
        public ChatSimpleUser GetUser(string id)
        {
            if (id == null) return null;
            if (_users.TryGetValue(id, out var user))
                return user;
            return null;
        }
        public ChatSimpleUser GetUserByName(string name)
        {
            if (name == null) return null;
            if (_userNameMap.TryGetValue(name, out var id))
                return GetUser(id);
            return null;
        }
        internal void AddUser(ChatSimpleUser user)
        {
            _users[user.Id] = user;
            _userNameMap[user.Name] = user.Id;
        }
        internal ChatSimpleUser RemoveUser(string id)
        {
            if (id == null) return null;
            if (_users.TryRemove(id, out var user))
            {
                _userNameMap.Remove(user.Name, out _);
                return user;
            }
            return null;
        }

        public ChatMessage GetMessage(string id)
            => _messages?.Get(id);
        public IReadOnlyCollection<ChatMessage> GetMessages(int count)
            => _messages?.GetMany(count);

        internal void AddMessage(ChatMessage msg)
            => _messages?.Add(msg);
        internal ChatMessage RemoveMessage(string id)
            => _messages?.Remove(id);
        internal IReadOnlyCollection<ChatMessage> ClearMessages()
            => _messages.RemoveAll();

        // Chat Methods
        public Task SendMessageAsync(string message)
            => Twitch.SendMessageAsync(Name, message);
        public Task SendAnnouncementAsync(string message, AnnouncementColor? color = null)
            => Twitch.Rest.SendAnnouncementAsync(Id, message, color);
        public Task SendShoutoutAsync(string channelId)
            => Twitch.Rest.SendShoutoutAsync(Id, channelId);
        public Task<IReadOnlyCollection<RestSimpleUser>> GetChattersAsync(int count = 20)
            => Twitch.Rest.GetChattersAsync(Id, count);
        public Task<IReadOnlyCollection<RestEmote>> GetEmotesAsync()
            => Twitch.Rest.GetEmotesAsync(Id);
        public Task<ChatSettings> GetChatSettingsAsync()
            => Twitch.Rest.GetChatSettingsAsync(Id);
        public Task<ChatSettings> ModifyChatSettingsAsync(Action<PatchChatSettingsBody> func)
            => Twitch.Rest.ModifyChatSettingsAsync(Id, func);

        // Rest Methods

        /// <summary> Get more info about this channel. </summary>
        public Task<RestChannel> GetChannelAsync()
            => Twitch.Rest.GetChannelAsync(Id);

        /// <summary> Get the user associated with this channel. </summary>
        public Task<RestUser> GetUserAsync()
            => Twitch.Rest.GetUserByIdAsync(Id);

        public Task<RestFollower> GetFollowerAsync(string userId)
            => Twitch.Rest.GetFollowerAsync(userId, Id);
        public Task<(IReadOnlyCollection<RestFollower> Followers, int Total)> GetFollowersAsync(int count = 20)
            => Twitch.Rest.GetFollowersAsync(Id, count);
    }
}