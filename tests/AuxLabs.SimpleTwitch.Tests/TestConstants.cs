namespace AuxLabs.SimpleTwitch.Tests
{
    public static class TestConstants
    {
        public const string BaseUrl = "http://localhost:8080/";
        public const string MockApiUrl = BaseUrl + "mock/";
        public const string UnitsApiUrl = BaseUrl + "units/";
        public const string WebSocketUrl = "ws://localhost:8080/eventsub";

        public static string AllScopes
            => string.Join(" ", 
                AnalyticScopes, 
                ChannelReadScopes, 
                ChannelManageScopes, 
                ModerationReadScopes, 
                ModerationManageScopes, 
                UserReadScopes, 
                UserManageScopes, 
                MiscScopes);

        public const string AnalyticScopes =
            "analytics:read:extensions " +
            "analytics:read:games";

        public const string ChannelReadScopes =
            "channel:read:charity " +
            "channel:read:editors " +
            "channel:read:goals " +
            "channel:read:hype_train " +
            "channel:read:polls " +
            "channel:read:predictions " +
            "channel:read:redemptions " +
            "channel:read:stream_key " +
            "channel:read:subscriptions " +
            "channel:read:vips";
        public const string ChannelManageScopes =
            "channel:edit:commercial " +
            "channel:manage:broadcast " +
            "channel:manage:extensions " +
            "channel:manage:moderators " +
            "channel:manage:polls " +
            "channel:manage:predictions " +
            "channel:manage:raids " +
            "channel:manage:redemptions " +
            "channel:manage:schedule " +
            "channel:manage:videos " +
            "channel:manage:vips";

        public const string ModerationReadScopes =
            "moderation:read " +
            "moderator:read:automod_settings " +
            "moderator:read:blocked_terms " +
            "moderator:read:chat_settings " +
            "moderator:read:chatters " +
            "moderator:read:shield_mode";
        public const string ModerationManageScopes =
            "moderator:manage:announcements " +
            "moderator:manage:automod " +
            "moderator:manage:automod_settings " +
            "moderator:manage:banned_users " +
            "moderator:manage:blocked_terms " +
            "moderator:manage:chat_messages " +
            "moderator:manage:chat_settings " +
            "moderator:manage:shield_mode";

        public const string UserReadScopes =
            "user:read:blocked_users " +
            "user:read:broadcast " +
            "user:read:email " +
            "user:read:follows " +
            "user:read:subscriptions";
        public const string UserManageScopes =
            "user:edit " +
            "user:edit:follows " +
            "user:manage:blocked_users " +
            "user:manage:chat_color " +
            "user:manage:whispers";

        public const string MiscScopes = 
            "bits:read " +
            "clips:edit " +
            "channel:moderate " +
            "chat:edit " +
            "chat:read " +
            "whispers:read " +
            "whispers:edit";
    }
}
