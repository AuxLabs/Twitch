namespace AuxLabs.SimpleTwitch
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
    }
}
