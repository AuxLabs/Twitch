namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetShieldModeArgs : PutShieldModeArgs
    {
        public new string[] Scopes { get; } = { "moderator:read:shield_mode", "moderator:manage:shield_mode" };
    }
}
