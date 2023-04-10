namespace AuxLabs.Twitch
{
    public interface ISimpleUser : IPartialUser
    {
        string DisplayName { get; }
    }
}
