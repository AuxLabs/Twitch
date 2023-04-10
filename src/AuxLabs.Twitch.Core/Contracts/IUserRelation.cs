namespace AuxLabs.Twitch
{
    public interface IUserRelation : ISimpleUser
    {
        string RelatedId { get; }
        string RelatedName { get; }
        string RelatedDisplayName { get; }
    }
}
