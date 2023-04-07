namespace AuxLabs.Twitch
{
    public interface IChannel : IEntity<string>
    {
        string Name { get; }
    }
}
