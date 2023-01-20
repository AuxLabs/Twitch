﻿namespace AuxLabs.SimpleTwitch
{
    public class MissingScopeException : TwitchException
    {
        public MissingScopeException(string scope)
            : this(new[] { scope }) { }
        public MissingScopeException(IEnumerable<string> scopes)
            : base($"Missing required scopes: {string.Join(", ", scopes)}") { }
    }
}
