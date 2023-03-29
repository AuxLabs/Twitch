namespace AuxLabs.Twitch
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
