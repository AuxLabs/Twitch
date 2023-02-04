namespace AuxLabs.SimpleTwitch
{
    public interface IChannel : IEntity<string>
    {
        string Name { get; }
    }
}
