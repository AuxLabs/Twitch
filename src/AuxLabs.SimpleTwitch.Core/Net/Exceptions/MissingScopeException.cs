namespace AuxLabs.SimpleTwitch
{
    public class MissingScopeException : TwitchException
    {
        public string[] Scopes { get; }

        public MissingScopeException(params string[] scopes)
            : base($"Missing required scopes: {string.Join(", ", scopes)}")
        {
            Scopes = scopes;
        }
    }
}
