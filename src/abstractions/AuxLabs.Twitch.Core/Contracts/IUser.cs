namespace AuxLabs.Twitch
{
    public interface IUser : IEntity<string>
    {
        string Name { get; }
        string DisplayName { get; }
    }
}
