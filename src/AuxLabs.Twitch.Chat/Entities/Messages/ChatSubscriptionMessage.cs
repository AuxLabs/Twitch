using AuxLabs.Twitch.Chat.Models;
using UserNotice = AuxLabs.Twitch.Chat.Models.UserNoticeEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatSubscriptionMessage : ChatMessage
    {
        /// <summary> The total number of months the user has subscribed. </summary>
        public int TotalMonths { get; private set; }

        /// <summary> The number of consecutive months the user has subscribed. </summary>
        public int StreakMonths { get; private set; }

        /// <summary> Indicates whether the user wants their streaks shared. </summary>
        public bool IsStreakShared { get; private set; }

        /// <summary> The display name of the subscription plan. This may be a default name or one created by the channel owner </summary>
        public string SubscriptionName { get; private set; }

        /// <summary> The type of subscription plan being used. </summary>
        public SubscriptionType SubscriptionType { get; private set; }

        internal ChatSubscriptionMessage(TwitchChatClient twitch, string id, ChatSimpleChannel channel, ChatChannelUser author)
            : base(twitch, id, channel, author) { }

        internal static ChatSubscriptionMessage Create(TwitchChatClient twitch, UserNotice model, ChatSimpleChannel channel, ChatChannelUser author)
        {
            var entity = new ChatSubscriptionMessage(twitch, model.Tags.MessageId, channel, author);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(UserNotice model)
        {
            var tags = (SubscriptionTags)model.Tags;
            base.Update(model, null);
            TotalMonths = tags.TotalMonths;
            StreakMonths = tags.StreakMonths;
            IsStreakShared = tags.IsStreakShared;
            SubscriptionName = tags.SubscriptionName;
            SubscriptionType = tags.SubscriptionType;
        }
    }
}
