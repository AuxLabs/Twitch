using RestEase;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "AuxLabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        [Header("Client-ID")]
        string ClientId { get; set; }

        #region Ads

        /// <summary> Starts a commercial on the specified channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:edit:commercial</c> scope. </remarks>
        /// <returns> A single <see cref="Commercial"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Post("channels/commercial")]
        Task<TwitchResponse<Commercial>> PostCommercialAsync([Body] PostCommercialBody args);

        #endregion
        #region Analytics

        /// <summary> Gets an analytics report for one or more extensions. The response contains the URLs used to download the reports (CSV files). </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>analytics:read:extensions</c> scope. </remarks>
        /// <returns> A collection of <see cref="ExtensionAnalytic"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("analytics/extensions")]
        Task<TwitchMetaResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync([QueryMap] GetExtensionAnalyticsArgs args);

        /// <summary> Gets an analytics report for one or more games. The response contains the URLs used to download the reports (CSV files). </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>analytics:read:games</c> scope. </remarks>
        /// <returns> A collection of <see cref="GameAnalytic"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("analytics/games")]
        Task<TwitchMetaResponse<GameAnalytic>> GetGameAnalyticsAsync([QueryMap] GetGameAnalyticsArgs args);

        #endregion
        #region Bits

        /// <summary> Gets the Bits leaderboard for the authenticated broadcaster. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>bits:read</c> scope. </remarks>
        /// <returns> A collection of <see cref="BitsUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("bits/leaderboard")]
        Task<TwitchMetaResponse<BitsUser>> GetBitsLeaderboardAsync([QueryMap] GetBitsLeaderboardArgs args);

        /// <summary> Gets a collection of Cheermotes that can be used to cheer bits in any bits-enabled channel. </summary>
        /// <returns> A collection of <see cref="Cheermote"/> objects. </returns>
        [Get("bits/cheermotes")]
        Task<TwitchResponse<Cheermote>> GetCheermotesAsync([QueryMap] GetCheermotesArgs args = null);

        /// <summary> Gets an extension’s list of transactions. </summary>
        /// <remarks> Requires an <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see>. </remarks>
        /// <returns> A collection of <see cref="ExtensionTransaction"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("extensions/transactions")]
        Task<TwitchMetaResponse<ExtensionTransaction>> GetExtensionTransactionsAsync([QueryMap] GetExtensionTransactionsArgs args);

        #endregion
        #region Channels

        /// <summary> Gets information about one or more channels. </summary>
        /// <returns> A collection of <see cref="Channel"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 404 Not Found </exception>
        [Get("channels")]
        Task<TwitchResponse<Channel>> GetChannelsAsync([QueryMap] GetChannelsArgs args);

        /// <summary> Updates a channel’s properties. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:broadcast</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("channels")]
        Task PatchChannelAsync([QueryMap] PatchChannelArgs args, [Body] PatchChannelBody body);

        /// <summary> Gets the broadcaster’s list editors. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:editors</c> scope. </remarks>
        /// <returns> A collection of <see cref="ChannelEditor"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channels/editors")]
        Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync([QueryMap] GetChannelEditorsArgs args);

        #endregion
        #region Channel Points

        /// <summary> Creates a custom reward in the broadcaster’s channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:redemptions</c> scope. </remarks>
        /// <returns> A single <see cref="Reward"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Post("channel_points/custom_rewards")]
        Task<TwitchResponse<Reward>> PostRewardsAsync([QueryMap] PostRewardArgs args, [Body] PostRewardBody body);

        /// <summary> Deletes a custom reward that the broadcaster created. Only the app that created a reward is able to delete it. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:redemptions</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("channel_points/custom_rewards")]
        Task DeleteRewardAsync([QueryMap] ManageRewardArgs args);

        /// <summary> Gets a list of custom rewards that the specified broadcaster created. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with either the <c>channel:read:redemptions</c> or <c>channel:manage:redemptions</c> scopes. </remarks>
        /// <returns> A collection of <see cref="Reward"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channel_points/custom_rewards")]
        Task<TwitchResponse<Reward>> GetRewardsAsync([QueryMap] GetRewardArgs args);

        /// <summary> Gets a list of redemptions for the specified custom reward. Only the app that created a reward is able to see it's redemptions. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with either the <c>channel:read:redemptions</c> or <c>channel:manage:redemptions</c> scopes. </remarks>
        /// <returns> A collection of <see cref="Redemption"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channel_points/custom_rewards/redemptions")]
        Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync([QueryMap] GetRedemptionsArgs args);

        /// <summary> Updates a custom reward. The app used to create the reward is the only app that may update the reward. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:redemptions</c> scope. </remarks>
        /// <returns> A collection of <see cref="Reward"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("channel_points/custom_rewards")]
        Task<TwitchResponse<Reward>> PatchRewardAsync([QueryMap] ManageRewardArgs args, [Body] PostRewardBody body);

        /// <summary> Updates a redemption’s status. The app used to create the reward is the only app that may update the redemption. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:redemptions</c> scope. </remarks>
        /// <returns> A collection of <see cref="Reward"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("channel_points/custom_rewards/redemptions")]
        Task<TwitchResponse<Redemption>> PatchRewardRedemptionAsync([Body] RedemptionStatus status, [QueryMap] ModifyRedemptionsArgs args);

        #endregion
        #region Charity

        /// <summary> Gets information about the charity campaign that a broadcaster is running. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:charity</c> scope. </remarks>
        /// <returns> A <see cref="CharityCampaign"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("charity/campaigns")]
        Task<TwitchResponse<CharityCampaign>> GetCharityCampaignAsync([Query("broadcaster_id")] string broadcasterId);

        /// <summary> Gets the list of donations that users have made to the broadcaster’s active charity campaign. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:charity</c> scope. </remarks>
        /// <returns> A <see cref="CharityDonation"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("charity/donations")]
        Task<TwitchMetaResponse<CharityDonation>> GetCharityDonationsAsync([QueryMap] GetCharityDonationsArgs args);

        #endregion
        #region Chat

        /// <summary> Gets the list of users that are connected to the broadcaster’s chat session. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:read:chatters</c> scope. </remarks>
        /// <returns> A collection of <see cref="SimpleUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("chat/chatters")]
        Task<TwitchMetaResponse<SimpleUser>> GetChattersAsync([QueryMap] GetChattersArgs args);

        /// <summary> Gets the broadcaster’s list of custom emotes. </summary>
        /// <returns> A collection of <see cref="Emote"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("chat/emotes")]
        Task<TwitchResponse<Emote>> GetEmotesAsync([Query("broadcaster_id")] string broadcasterId);

        /// <summary> Gets the list of global emotes. </summary>
        /// <returns> A collection of <see cref="GlobalEmote"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 401 Unauthorized </exception>
        [Get("chat/emotes/global")]
        Task<TwitchResponse<GlobalEmote>> GetEmotesAsync();

        /// <summary> Gets emotes for one or more specified emote sets. </summary>
        /// <returns> A collection of <see cref="Emote"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("chat/emotes/set")]
        Task<TwitchResponse<Emote>> GetEmoteSetsAsync([QueryMap] GetEmoteSetsArgs args);

        /// <summary> Gets the broadcaster’s list of custom chat badges. </summary>
        /// <returns> A collection of <see cref="Badge"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("chat/badges")]
        Task<TwitchResponse<Badge>> GetBadgesAsync([Query("broadcaster_id")] string broadcasterId);

        /// <summary> Gets Twitch’s list of chat badges, which users may use in any channel’s chat room. </summary>
        /// <returns> A collection of <see cref="Badge"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 401 Unauthorized </exception>
        [Get("chat/badges/global")]
        Task<TwitchResponse<Badge>> GetBadgesAsync();

        /// <summary> Gets the broadcaster’s chat settings. </summary>
        /// <returns> A single <see cref="ChatSettings"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("chat/settings")]
        Task<TwitchResponse<ChatSettings>> GetChatSettingsAsync([QueryMap] GetChatSettingsArgs args);

        /// <summary> Updates the broadcaster’s chat settings. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:chat_settings</c> scope. </remarks>
        /// <returns> A single <see cref="ChatSettings"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("chat/settings")]
        Task<TwitchResponse<ChatSettings>> PatchChatSettingsAsync([QueryMap] PatchChatSettingsArgs args, [Body] PatchChatSettingsBody body);

        /// <summary> Sends an announcement to the broadcaster’s chat room. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:announcements</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Post("chat/announcements")]
        Task PostChatAnnouncementAsync([Query("broadcaster_id")] string broadcasterId, [Query("moderator_id")] string moderatorId, [Body] PostAnnouncementArgs args);

        /// <summary> Sends a shoutout to the specified broadcaster. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:shoutouts</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("chat/shoutouts")]
        Task PostShoutoutAsync([QueryMap] PostShoutoutArgs args);

        /// <summary> Gets the color used for the user’s name in chat. </summary>
        /// <returns> A collection of <see cref="SimpleChatUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("chat/color")]
        Task<TwitchResponse<SimpleChatUser>> GetUserChatColorAsync([QueryMap] GetUserColorArgs args);

        /// <summary> Updates the color used for the user's name in chat. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:manage:chat_color</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Put("chat/color")]
        Task PutUserChatColor([QueryMap] PutUserChatColorArgs args);

        #endregion
        #region Clips

        /// <summary> Creates a clip from the broadcaster’s stream. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>clips:edit</c> scope. </remarks>
        /// <returns> A single <see cref="SimpleClip"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Post("clips")]
        Task<TwitchResponse<SimpleClip>> PostClipAsync([QueryMap] PostClipArgs args);

        /// <summary> Gets one or more video clips that were captured from streams. </summary>
        /// <returns> A collection of <see cref="Clip"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("clips")]
        Task<TwitchMetaResponse<Clip>> GetClipsAsync([QueryMap] GetClipsArgs args);

        #endregion
        #region Entitlements

        /// <summary> Gets the status of one or more redemption codes for a Bits reward. </summary>
        /// <remarks> Requires an <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see>. </remarks>
        /// <returns> A collection of <see cref="EntitlementCode"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        [Get("entitlements/codes")]
        Task<TwitchResponse<EntitlementCode>> GetCodeStatusAsync([QueryMap] CodeStatusArgs args);

        /// <summary> Gets an organization’s list of entitlements that have been granted to a game, a user, or both. </summary>
        /// <returns> A collection of <see cref="Entitlement"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        [Get("entitlements/drops")]
        Task<TwitchMetaResponse<Entitlement>> GetDropsStatusAsync([QueryMap] GetDropStatusArgs args);

        /// <summary> Updates the Drop entitlement’s fulfillment status. </summary>
        /// <returns> A collection of <see cref="EntitlementDrop"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Patch("entitlements/drops")]
        Task<TwitchResponse<EntitlementDrop>> PatchDropsStatusAsync([Body] PatchDropsStatusArgs args);

        /// <summary> Redeems one or more redemption codes. </summary>
        /// <remarks> Requires an <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see>. </remarks>
        /// <returns> A collection of <see cref="EntitlementCode"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        [Post("entitlements/codes")]
        Task<TwitchResponse<EntitlementCode>> PostCodeStatusAsync([QueryMap] CodeStatusArgs args);

        #endregion
        #region Extensions

        [Get("extensions/configurations")]
        Task<TwitchResponse<object>> GetExtensionConfigurationAsync([Query] object args);
        [Put("extensions/configurations")]
        Task<TwitchResponse<object>> PutExtensionConfigurationAsync([Query] object args);
        [Put("extensions/required_configuration")]
        Task<TwitchResponse<object>> PutExtensionRequiredConfigurationAsync([Query] object args);
        [Post("extensions/pubsub")]
        Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync([Query] object args);
        [Get("extensions/live")]
        Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync([Query] object args);
        [Get("extensions/jwt/secrets")]
        Task<TwitchResponse<object>> GetExtensionSecretsAsync([Query] object args);
        [Post("extensions/jwt/secrets")]
        Task<TwitchResponse<object>> PostExtensionSecretsAsync([Query] object args);
        [Post("extensions/chat")]
        Task<TwitchResponse<object>> PostExtensionChatMessageAsync([Query] object args);
        [Get("extensions")]
        Task<TwitchResponse<object>> GetExtensionsAsync([Query] object args);
        [Get("extensions/released")]
        Task<TwitchResponse<object>> GetReleasedExtensionsAsync([Query] object args);
        [Get("bits/extensions")]
        Task<TwitchResponse<object>> GetExtensionBitsProductsAsync([Query] object args);
        [Put("bits/extensions")]
        Task<TwitchResponse<object>> PutExtensionBitsProductsAsync([Query] object args);

        #endregion
        #region EventSub

        /// <summary> Creates an EventSub subscription. </summary>
        /// <remarks> Webhook transports require a <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see> and 
        /// Websocket transports require a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>. </remarks>
        /// <returns> An <see cref="EventSubResponse"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Post("eventsub/subscriptions")]
        Task<EventSubResponse> PostEventSubscriptionAsync([Body] PostEventSubscriptionArgs args);

        /// <summary> Deletes an EventSub subscription. </summary>
        /// <remarks> Webhook transports require a <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see> and 
        /// Websocket transports require a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("eventsub/subscriptions")]
        Task DeleteEventSubscriptionAsync([Query("id")] string eventsubId);

        /// <summary> Gets a collection of EventSub subscriptions that the client in the access token created. </summary>
        /// <remarks> Webhook transports require a <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see> and 
        /// Websocket transports require a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>. </remarks>
        /// <returns> An <see cref="EventSubResponse"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("eventsub/subscriptions")]
        Task<EventSubResponse> GetEventSubscriptionsAsync([QueryMap] GetEventSubscriptionsArgs args);

        #endregion
        #region Games

        /// <summary> Gets information about all broadcasts on Twitch. </summary>
        /// <returns> A collection of <see cref="Game"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("games/top")]
        Task<TwitchMetaResponse<Game>> GetTopGamesAsync([QueryMap] GetTopGamesArgs args);

        /// <summary> Gets information about specified categories or games. </summary>
        /// <returns> A collection of <see cref="Game"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("games")]
        Task<TwitchMetaResponse<Game>> GetGamesAsync([QueryMap] GetGamesArgs args);

        #endregion
        #region Goals

        /// <summary> Gets the broadcaster’s list of active goals. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:goals</c> scope. </remarks>
        /// <returns> A collection of <see cref="Goal"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("goals")]
        Task<TwitchResponse<Goal>> GetGoalsAsync([Query("broadcaster_id")] string broadcasterId);

        #endregion
        #region Hype Train

        /// <summary> Gets information about the broadcaster’s current or most recent Hype Train event. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:hype_train</c> scope. </remarks>
        /// <returns> A collection of <see cref="HypeTrainInfo"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("hypetrain/events")]
        Task<TwitchMetaResponse<HypeTrainInfo>> GetHypetrainEventsAsync([QueryMap] GetHypeTrainsArgs args);

        #endregion
        #region Moderation

        /// <summary> Checks whether AutoMod would flag the specified message for review. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderation:read</c> scope. </remarks>
        /// <returns> A collection of <see cref="MockMessage"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/enforcements/status")]
        Task<TwitchResponse<MockMessage>> PostEnforcementStatusAsync([Query("broadcaster_id")] string broadcasterId, [Body] PostEnforcementStatusBody body);

        /// <summary> Allow or deny the message that AutoMod flagged for review. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:automod</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/automod/message")]
        Task PostAutomodMessageAsync([QueryMap] PostAutomodMessageArgs args);

        /// <summary> Gets the broadcaster’s AutoMod settings. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:read:automod_settings</c> scope. </remarks>
        /// <returns> A single <see cref="AutomodSettings"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("moderation/automod/settings")]
        Task<TwitchResponse<AutomodSettings>> GetAutomodSettingsAsync([QueryMap] AutomodSettingsArgs args);

        /// <summary> Updates the broadcaster’s AutoMod settings. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:automod_settings</c> scope. </remarks>
        /// <returns> A single <see cref="AutomodSettings"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Put("moderation/automod/settings")]
        Task<TwitchResponse<AutomodSettings>> PutAutomodSettingsAsync([QueryMap] AutomodSettingsArgs args, [Body] PutAutomodSettingsBody body);

        /// <summary> Gets all users that the broadcaster banned or put in a timeout. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderation:read</c> or <c>moderator:manage:banned_users</c> scopes. </remarks>
        /// <returns> A single <see cref="BannedUser"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("moderation/banned")]
        Task<TwitchMetaResponse<BannedUser>> GetBannedUsersAsync([QueryMap] GetBannedUsersArgs args);

        /// <summary> Bans a user from participating in the specified broadcaster’s chat room or puts them in a timeout. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c> moderator:manage:banned_users</c> scope. </remarks>
        /// <returns> A collection of <see cref="Ban"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/bans")]
        Task<TwitchResponse<Ban>> PostBanAsync([QueryMap] PostBanArgs args, [Body] PostBanBody body);

        /// <summary> Removes the ban or timeout that was placed on the specified user. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c> moderator:manage:banned_users</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("moderation/bans")]
        Task DeleteBanAsync([QueryMap] DeleteBanArgs args);

        [Get("moderation/blocked_terms")]
        Task<TwitchResponse<object>> GetBlockedTermsAsync([Query] object args);

        [Post("moderation/blocked_terms")]
        Task<TwitchResponse<object>> PostBlockedTermAsync([Query] object args);

        [Delete("moderation/blocked_term")]
        Task<TwitchResponse<object>> DeleteBlockedTermAsync([Query] object args);

        [Delete("moderation/chat")]
        Task<TwitchResponse<object>> DeleteChatMessagesAsync([Query] object args);

        [Get("moderation/moderators")]
        Task<TwitchResponse<object>> GetModeratorsAsync([Query] object args);

        [Post("moderation/moderators")]
        Task<TwitchResponse<object>> PostModeratorAsync([Query] object args);

        [Delete("moderation/moderators")]
        Task<TwitchResponse<object>> DeleteModeratorAsync([Query] object args);

        [Get("channels/vips")]
        Task<TwitchResponse<object>> GetVipsAsync([Query] object args);

        [Post("channels/vips")]
        Task<TwitchResponse<object>> PostVipAsync([Query] object args);

        [Delete("channels/vips")]
        Task<TwitchResponse<object>> DeleteVipAsync([Query] object args);

        [Put("moderation/shield_mode")]
        Task<TwitchResponse<object>> PutShieldModeAsync([Query] object args);

        [Get("moderation/shield_mode")]
        Task<TwitchResponse<object>> GetShieldModeAsync([Query] object args);

        #endregion
        #region Polls

        /// <summary> Gets a list of polls that the broadcaster created. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:polls</c> or <c>channel:manage:polls</c> scopes. </remarks>
        /// <returns> A collection of <see cref="Poll"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("polls")]
        Task<TwitchMetaResponse<Poll>> GetPollAsync([QueryMap] GetPredictionsArgs args);

        /// <summary> Creates a poll that viewers in the broadcaster’s channel can vote on. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:polls</c> scope. </remarks>
        /// <returns> A single <see cref="Poll"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Post("polls")]
        Task<TwitchResponse<Poll>> PostPollAsync([Body] PutPollArgs args);

        /// <summary> Ends an active poll. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:polls</c> scope. </remarks>
        /// <returns> A single <see cref="Poll"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("polls")]
        Task<TwitchResponse<Poll>> PatchPollAsync([Body] PatchPollArgs args);

        #endregion
        #region Predictions

        /// <summary> Gets a list of Channel Points Predictions that the broadcaster created. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:predictions</c> or <c>channel:manage:predictions</c> scopes. </remarks>
        /// <returns> A collection of <see cref="Prediction"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("predictions")]
        Task<TwitchMetaResponse<Prediction>> GetPredictionAsync([QueryMap] GetPredictionsArgs args);

        /// <summary> Creates a Channel Points Prediction. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:predictions</c> scope. </remarks>
        /// <returns> A single <see cref="Prediction"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Post("predictions")]
        Task<TwitchResponse<Prediction>> PostPredictionAsync([Body] PostPredictionArgs args);

        /// <summary> Locks, resolves, or cancels a Channel Points Prediction. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:predictions</c> scope. </remarks>
        /// <returns> A single <see cref="Prediction"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("predictions")]
        Task<TwitchResponse<Prediction>> PatchPredictionaAsync([Body] PostPredictionArgs args);

        #endregion
        #region Raids

        /// <summary> Raid another channel by sending the broadcaster’s viewers to the targeted channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:raids</c> scope. </remarks>
        /// <returns> A single <see cref="Raid"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Post("raids")]
        Task<TwitchResponse<Raid>> PostRaidAsync([QueryMap] PostRaidArgs args);

        /// <summary> Cancel a pending raid. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:raids</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("raids")]
        Task DeleteRaidAsync([QueryMap] DeleteRaidArgs args);

        #endregion
        #region Schedule

        [Get("schedule")]
        Task<TwitchResponse<object>> GetScheduleAsync([Query] object args);
        [Get("schedule/icalendar")]
        Task<TwitchResponse<object>> GetCalendarAsync([Query] object args);
        [Patch("schedule/settings")]
        Task<TwitchResponse<object>> PatchScheduleAsync([Query] object args);
        [Post("schedule/segment")]
        Task<TwitchResponse<object>> PostScheduleSegmentAsync([Query] object args);
        [Patch("schedule/segment")]
        Task<TwitchResponse<object>> PatchScheduleSegmentAsync([Query] object args);
        [Delete("schedule/segment")]
        Task<TwitchResponse<object>> DeleteScheduleSegmentAsync([Query] object args);

        #endregion
        #region Search

        [Get("search/categories")]
        Task<TwitchResponse<object>> GetCategoriesAsync([Query] object args);
        [Get("search/channels")]
        Task<TwitchResponse<object>> GetChannelsAsync(SearchChannelsArgs args);

        #endregion
        #region Music

        [Get("soundtrack/current_track")]
        Task<TwitchResponse<object>> GetCurrentTrackAsync([Query] object args);
        [Get("soundtrack/playlist")]
        Task<TwitchResponse<object>> GetCurrentPlaylistAsync([Query] object args);
        [Get("soundtrack/playlists")]
        Task<TwitchResponse<object>> GetPlaylistsAsync([Query] object args);

        #endregion
        #region Broadcasts

        /// <summary> Gets the channel’s broadcast key. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:read:stream_key</c> scope. </remarks>
        /// <returns> A single <see cref="string"/> object that represents the broadcaster's stream key. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("stream/key")]
        Task<TwitchResponse<string>> GetBroadcastKeyAsync([QueryMap] GetBroadcastKeyArgs args);

        /// <summary> Gets a list of all broadcasts. </summary>
        /// <returns> A collection of <see cref="Broadcast"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("streams")]
        Task<TwitchMetaResponse<Broadcast>> GetBroadcastsAsync([QueryMap] GetBroadcastsArgs args);

        /// <summary> Gets the list of broadcasters that the user follows and that are streaming live. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:follows</c> scope. </remarks>
        /// <returns> A collection of <see cref="Broadcast"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("streams/followed")]
        Task<TwitchMetaResponse<Broadcast>> GetFollowedBroadcastsAsync([QueryMap] GetFollowedBroadcastsArgs args);

        /// <summary> Adds a marker to a live stream. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:broadcast</c> scope. </remarks>
        /// <returns> A single <see cref="BroadcastMarker"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Post("streams/markers")]
        Task<TwitchResponse<BroadcastMarker>> PostBroadcastMarkerAsync([Body] PostBroadcastMarkerBody body);

        /// <summary> Gets a list of markers from the user’s most recent stream or from the specified VOD/video. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:broadcast</c> or <c>channel:manage:broadcast</c> scopes. </remarks>
        /// <returns> A collection of <see cref="BroadcastMarker"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Get("streams/markers")]
        Task<TwitchMetaResponse<BroadcastMarker>> GetBroadcastMarkersAsync([QueryMap] GetBroadcastMarkersArgs args);

        #endregion
        #region Subscriptions

        /// <summary> Updates the specified user’s information. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// or <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see>
        /// with the <c>channel:read:subscriptions</c> scope. </remarks>
        /// <returns> A collection of <see cref="Subscription"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("subscriptions")]
        Task<TwitchMetaResponse<Subscription>> GetSubscriptionsAsync([QueryMap] GetSubscriptionsArgs args);

        /// <summary> Checks whether the user subscribes to the broadcaster’s channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// or <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see>
        /// with the <c>channel:read:subscriptions</c> scope. </remarks>
        /// <returns> A single <see cref="SimpleSubscription"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("subscriptions/user")]
        Task<TwitchResponse<SimpleSubscription>> GetSubscriberAsync([QueryMap] GetSubscriberArgs args);

        #endregion
        #region Teams

        /// <summary> Gets information about one or more users. </summary>
        /// <returns> A collection of <see cref="ChannelTeam"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("teams/channel")]
        Task<TwitchResponse<ChannelTeam>> GetTeamsAsync([Query("broadcaster_id")] string broadcasterId);

        /// <summary> Gets information about the specified Twitch team. </summary>
        /// <returns> A single <see cref="Team"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("teams")]
        Task<TwitchResponse<Team>> GetTeamAsync([QueryMap] GetTeamArgs args);

        #endregion
        #region Users

        /// <summary> Gets information about one or more users. </summary>
        /// <returns> A collection of <see cref="User"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("users")]
        Task<TwitchResponse<User>> GetUsersAsync([QueryMap] GetUsersArgs args);

        /// <summary> Updates the specified user’s information. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:edit</c> scope. </remarks>
        /// <returns> A single <see cref="User"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Put("users")]
        Task<TwitchResponse<User>> PutUserAsync([Query("description")] string description);

        /// <summary> Gets information about users that are following other users. </summary>
        /// <returns> A collection of <see cref="Follower"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("users/follows")]
        Task<TwitchMetaResponse<Follower>> GetFollowsAsync([QueryMap] GetFollowsArgs args);

        /// <summary> Gets the list of users that the broadcaster has blocked. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:blocked_users</c> scope. </remarks>
        /// <returns> A collection of <see cref="SimpleUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("users/blocks")]
        Task<TwitchMetaResponse<SimpleUser>> GetBlocksAsync([QueryMap] GetBlocksArgs args);

        /// <summary> Blocks the specified user from interacting with or having contact with the broadcaster. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:manage:blocked_users</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Put("users/blocks")]
        Task PutBlockAsync([QueryMap] PutBlockArgs args);

        /// <summary> Removes the user from the broadcaster’s list of blocked users. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:manage:blocked_users</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("users/blocks")]
        Task DeleteBlockAsync([Query("target_user_id")] string targetUserId);

        /// <summary> Gets a list of all extensions (both active and inactive) that the broadcaster has installed. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:broadcast</c> or <c>user:edit:broadcast</c> scope. Inactive extensions are only included with the <c>user:edit:broadcast</c> scope. </remarks>
        /// <returns> A collection of <see cref="Extension"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("users/extensions/list")]
        Task<TwitchResponse<Extension>> GetUserExtensionsAsync();

        /// <summary> Gets a list of all extensions (both active and inactive) that the broadcaster has installed. </summary>
        /// <remarks> Requires an <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see> or a
        /// <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see> with the 
        /// <c>user:read:broadcast</c> or <c>user:edit:broadcast</c> scope. </remarks>
        /// <returns> A single <see cref="ExtensionMap"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("users/extensions")]
        Task<TwitchResponse<ExtensionMap>> GetActiveExtensionsAsync([Query("user_id")] string userId);

        /// <summary> Updates an installed extension’s information. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:broadcast</c> or <c>user:edit:broadcast</c> scope. </remarks>
        /// <returns> A single <see cref="ExtensionMap"/> object. </returns>
        /// <exception cref="TwitchRestException"> 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Put("users/extensions")]
        Task<TwitchResponse<ExtensionMap>> PutExtensionsAsync([Body] ExtensionMap args);

        #endregion
        #region Videos

        /// <summary> Gets information about one or more published videos. </summary>
        /// <returns> A collection of <see cref="Video"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("videos")]
        Task<TwitchMetaResponse<Video>> GetVideosAsync([QueryMap] GetVideosArgs args);

        /// <summary> Deletes one or more videos. You may delete past broadcasts, highlights, or uploads. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:videos</c> scope. </remarks>
        /// <returns> A collection of <see cref="string"/> that represent the deleted videos' ids. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("videos")]
        Task<TwitchResponse<string>> DeleteVideoAsync([QueryMap] DeleteVideosArgs args);

        #endregion
        #region Whispers

        /// <summary> Sends a whisper message to the specified user. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:manage:whispers</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not found </exception>
        /// <exception cref="MissingScopeException" />
        [Post("whispers")]
        Task PostWhisperAsync([Query("from_user_id")] string fromUserId, [Query("to_user_id")] string toUserId, [Body] string message);

        #endregion
    }
}
