namespace AuxLabs.SimpleTwitch
{
    public interface IUserRelation : IUser
    {
        string RelatedId { get; set; }
        string RelatedName { get; set; }
        string RelatedDisplayName { get; set; }
    }
}
