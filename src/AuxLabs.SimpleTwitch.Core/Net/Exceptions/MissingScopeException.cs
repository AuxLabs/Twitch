namespace AuxLabs.SimpleTwitch
{
    public class MissingScopeException : TwitchException
    {
        public MissingScopeException(params string[] scopes)
            : base($"Missing required scopes: {string.Join(", ", scopes)}") { }
    }
}
