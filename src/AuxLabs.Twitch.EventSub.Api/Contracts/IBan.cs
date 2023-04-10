namespace AuxLabs.Twitch.EventSub
{
    public interface IBan
    {
        public ISimpleUser User { get; }
        public ISimpleUser Broadcaster { get;  }
        public ISimpleUser Moderator { get; }
    }
}
