namespace AuxLabs.SimpleTwitch
{
    public interface IUser : IEntity<string>
    {
        string Name { get; set; }
        string DisplayName { get; set; }
    }
}
