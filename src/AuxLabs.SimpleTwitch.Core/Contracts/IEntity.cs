namespace AuxLabs.SimpleTwitch
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
