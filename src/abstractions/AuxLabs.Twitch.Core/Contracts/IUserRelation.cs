namespace AuxLabs.Twitch
{
    public interface IUserRelation : IUser
    {
        string RelatedId { get; }
        string RelatedName { get; }
        string RelatedDisplayName { get; }
    }
}
