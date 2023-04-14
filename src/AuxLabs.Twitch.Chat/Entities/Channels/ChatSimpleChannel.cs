using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using RoomState = AuxLabs.Twitch.Chat.Models.RoomStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatSimpleChannel : ChatEntity<string>
    {
        private readonly ConcurrentDictionary<string, string> _userNameMap;
        private readonly EntityCache<string, ChatMessage> _messages;
        private readonly EntityCache<string, ChatSimpleUser> _users;

        /// <summary> The currently authorized user </summary>
        public ChatChannelSelfUser MyUser { get; internal set; }

        /// <summary> The channel's name </summary>
        public string Name { get; private set; }

        internal ChatSimpleChannel(TwitchChatClient twitch, string id)
            : base(twitch, id) 
        {
            _userNameMap = new ConcurrentDictionary<string, string>();
            _messages = new EntityCache<string, ChatMessage>(twitch.MessageCacheSize);
            _users = new EntityCache<string, ChatSimpleUser>(twitch.UserCacheSize);
        }

        public override string ToString() => $"{Name} ({Id})";

        #region Create

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

        #endregion

        #region Cache

        // Users
        public ChatSimpleUser GetUser(string id)
            => _users?.Get(id);
        public ChatSimpleUser GetUserByName(string name)
        {
            if (name == null) return null;
            if (_userNameMap.TryGetValue(name, out var id))
                return GetUser(id);
            return null;
        }

        internal void AddUser(ChatSimpleUser msg)
            => _users?.Add(msg);
        internal ChatSimpleUser RemoveUser(string id)
        {
            if (id == null) return null;

            var user = _users?.Remove(id);
            if (user == null)
                return null;

            _userNameMap.Remove(user.Name, out _);
            return user;

        }
        internal IReadOnlyCollection<ChatSimpleUser> ClearUsers()
            => _users.RemoveAll();

        // Messages
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

        #endregion
        #region Chat Requests

        public Task SendMessageAsync(string message)
            => Twitch.SendMessageAsync(Name, message);

        #endregion
    }
}
