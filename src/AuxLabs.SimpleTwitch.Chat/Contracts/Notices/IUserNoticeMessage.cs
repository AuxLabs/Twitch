namespace AuxLabs.SimpleTwitch.Chat
{
    public interface IUserNoticeMessage : IChatMessage
    {
        UserNoticeType NoticeType { get; }
        string SystemMessage { get; }
    }
}
