namespace AuxLabs.Twitch.Chat
{
    public interface IUserNoticeMessage : IChatMessage
    {
        UserNoticeType NoticeType { get; }
        string SystemMessage { get; }
    }
}
