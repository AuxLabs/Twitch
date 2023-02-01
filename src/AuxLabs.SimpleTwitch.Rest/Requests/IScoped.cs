namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> Indicates that a method requires special authentication to be used. </summary>
    public interface IScoped
    {
        /// <summary> The scopes required for this request. </summary>
        string[] Scopes { get; }
    }
}
