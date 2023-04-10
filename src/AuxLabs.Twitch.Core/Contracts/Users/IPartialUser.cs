namespace AuxLabs.Twitch
{
    public interface IPartialUser : IEntity<string>
    {
        string Name { get; }
    }
}
