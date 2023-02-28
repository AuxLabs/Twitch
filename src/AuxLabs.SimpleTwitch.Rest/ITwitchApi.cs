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

        /// <summary> Gets a list of broadcasters that the specified user follows. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>user:read:follows</c> scope. </remarks>
        /// <returns> A collection of <see cref="FollowedChannel"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channels/followed")]
        Task<TwitchMetaResponse<FollowedChannel>> GetFollowedChannelsAsync([QueryMap] GetFollowedChannelsArgs args);

        /// <summary> Gets a list of users that follow the specified broadcaster. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:read:followers</c> scope. </remarks>
        /// <returns> A collection of <see cref="Follower"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channels/followed")]
        Task<TwitchMetaResponse<Follower>> GetFollowersAsync([QueryMap] GetFollowersArgs args);

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
        Task<TwitchResponse<CharityCampaign>> GetCharityCampaignAsync([QueryMap] GetCharityCampaignArgs args);

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
        Task<TwitchResponse<Emote>> GetEmotesAsync([QueryMap] GetEmotesArgs args);

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
        Task<TwitchResponse<Badge>> GetBadgesAsync([QueryMap] GetBadgesArgs args);

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
        Task PostChatAnnouncementAsync([QueryMap] PostAnnouncementArgs args, [Body] PostAnnouncementBody body);

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
        //#region Extensions

        //[Get("extensions/configurations")]
        //Task<TwitchResponse<object>> GetExtensionConfigurationAsync([Query] object args);
        //[Put("extensions/configurations")]
        //Task<TwitchResponse<object>> PutExtensionConfigurationAsync([Query] object args);
        //[Put("extensions/required_configuration")]
        //Task<TwitchResponse<object>> PutExtensionRequiredConfigurationAsync([Query] object args);
        //[Post("extensions/pubsub")]
        //Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync([Query] object args);
        //[Get("extensions/live")]
        //Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync([Query] object args);
        //[Get("extensions/jwt/secrets")]
        //Task<TwitchResponse<object>> GetExtensionSecretsAsync([Query] object args);
        //[Post("extensions/jwt/secrets")]
        //Task<TwitchResponse<object>> PostExtensionSecretsAsync([Query] object args);
        //[Post("extensions/chat")]
        //Task<TwitchResponse<object>> PostExtensionChatMessageAsync([Query] object args);
        //[Get("extensions")]
        //Task<TwitchResponse<object>> GetExtensionsAsync([Query] object args);
        //[Get("extensions/released")]
        //Task<TwitchResponse<object>> GetReleasedExtensionsAsync([Query] object args);
        //[Get("bits/extensions")]
        //Task<TwitchResponse<object>> GetExtensionBitsProductsAsync([Query] object args);
        //[Put("bits/extensions")]
        //Task<TwitchResponse<object>> PutExtensionBitsProductsAsync([Query] object args);

        //#endregion
        #region EventSub

        /// <summary> Creates an EventSub subscription. </summary>
        /// <remarks> Webhook transports require a <see href="https://dev.twitch.tv/docs/authentication#app-access-tokens">app access token</see> and 
        /// Websocket transports require a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>. </remarks>
        /// <returns> An <see cref="EventSubResponse"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Post("eventsub/subscriptions")]
        Task<EventSubResponse> PostEventSubscriptionAsync([Body] PostEventSubscriptionBody args);

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
        Task<TwitchResponse<Goal>> GetGoalsAsync([QueryMap] GetGoalsArgs args);

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
        Task<TwitchResponse<MockMessage>> PostEnforcementStatusAsync([QueryMap] PostEnforcementStatusArgs args, [Body] PostEnforcementStatusBody body);

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
        /// with the <c>moderator:manage:banned_users</c> scope. </remarks>
        /// <returns> A collection of <see cref="Ban"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/bans")]
        Task<TwitchResponse<Ban>> PostBanAsync([QueryMap] PostBanArgs args, [Body] PostBanBody body);

        /// <summary> Removes the ban or timeout that was placed on the specified user. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:banned_users</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden, 409 Conflict </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("moderation/bans")]
        Task DeleteBanAsync([QueryMap] DeleteBanArgs args);

        /// <summary> Gets the broadcaster’s list of non-private, blocked words or phrases. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:read:blocked_terms</c> or <c>moderator:manage:blocked_terms</c> scopes. </remarks>
        /// <returns> A collection of <see cref="BlockedTerm"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("moderation/blocked_terms")]
        Task<TwitchMetaResponse<BlockedTerm>> GetBlockedTermsAsync([QueryMap] GetBlockedTermsArgs args);

        /// <summary> Gets the broadcaster’s list of non-private, blocked words or phrases. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:blocked_terms</c> scope. </remarks>
        /// <returns> A single <see cref="BlockedTerm"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/blocked_terms")]
        Task<TwitchResponse<BlockedTerm>> PostBlockedTermAsync([QueryMap] PostBlockedTermArgs args, [Body] PostBlockedTermBody body);

        /// <summary> Removes the word or phrase from the broadcaster’s list of blocked terms. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:blocked_terms</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("moderation/blocked_term")]
        Task DeleteBlockedTermAsync([QueryMap] DeleteBlockedTermsArgs args);

        /// <summary> Removes a single chat message or all chat messages from the broadcaster’s chat room. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:chat_messages</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("moderation/chat")]
        Task DeleteChatMessagesAsync([QueryMap] DeleteMessageArgs args);

        /// <summary> Gets all users allowed to moderate the broadcaster’s chat room. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderation:read</c> or <c>channel:manage:moderators</c> scopes. </remarks>
        /// <returns> A collection of <see cref="SimpleUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Fordbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("moderation/moderators")]
        Task<TwitchMetaResponse<SimpleUser>> GetModeratorsAsync([QueryMap] GetModeratorsArgs args);

        /// <summary> Adds a moderator to the broadcaster’s chat room. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:moderators</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 422 Unprocessable </exception>
        /// <exception cref="MissingScopeException" />
        [Post("moderation/moderators")]
        Task PostModeratorAsync([QueryMap] ManageModeratorArgs args);

        /// <summary> Removes a moderator from the broadcaster’s chat room. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:moderators</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 422 Unprocessable </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("moderation/moderators")]
        Task DeleteModeratorAsync([QueryMap] ManageModeratorArgs args);

        /// <summary> Gets a list of the broadcaster’s VIPs. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderation:read</c> or <c>channel:manage:moderators</c> scopes. </remarks>
        /// <returns> A collection of <see cref="SimpleUser"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Get("channels/vips")]
        Task<TwitchMetaResponse<SimpleUser>> GetVipsAsync([QueryMap] GetVipsArgs args);

        /// <summary> Adds the specified user as a VIP in the broadcaster’s channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:vips</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found, 409 Conflict, 422 Unprocessable, 425 Too Early </exception>
        /// <exception cref="MissingScopeException" />
        [Post("channels/vips")]
        Task PostVipAsync([QueryMap] ManageVipArgs args);

        /// <summary> Removes the specified user as a VIP in the broadcaster’s channel. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:vips</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found, 422 Unprocessable </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("channels/vips")]
        Task DeleteVipAsync([QueryMap] ManageVipArgs args);

        /// <summary> Activates or deactivates the broadcaster’s Shield Mode. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:manage:shield_mode</c> scope. </remarks>
        /// <returns> A single <see cref="ShieldMode"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Put("moderation/shield_mode")]
        Task<TwitchResponse<ShieldMode>> PutShieldModeAsync([QueryMap] PutShieldModeArgs args, [Body] PutShieldModeBody body);

        /// <summary> Activates or deactivates the broadcaster’s Shield Mode. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>moderator:read:shield_mode</c> or <c>moderator:manage:shield_mode</c> scopes. </remarks>
        /// <returns> A single <see cref="ShieldMode"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Get("moderation/shield_mode")]
        Task<TwitchResponse<ShieldMode>> GetShieldModeAsync([QueryMap] GetShieldModeArgs args);

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
        Task<TwitchResponse<Poll>> PostPollAsync([Body] PutPollBody args);

        /// <summary> Ends an active poll. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:polls</c> scope. </remarks>
        /// <returns> A single <see cref="Poll"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("polls")]
        Task<TwitchResponse<Poll>> PatchPollAsync([Body] PatchPollBody args);

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
        Task<TwitchResponse<Prediction>> PostPredictionAsync([Body] PostPredictionBody args);

        /// <summary> Locks, resolves, or cancels a Channel Points Prediction. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:predictions</c> scope. </remarks>
        /// <returns> A single <see cref="Prediction"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("predictions")]
        Task<TwitchResponse<Prediction>> PatchPredictionaAsync([Body] PostPredictionBody args);

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

        /// <summary> Gets the broadcaster’s streaming schedule. </summary>
        /// <returns> A single <see cref="Schedule"/> object with a collection of <see cref="ScheduleSegment"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found </exception>
        [Get("schedule")]
        Task<TwitchMetaResponse<Schedule>> GetScheduleAsync([QueryMap] GetScheduleArgs args);

        /// <summary> Updates the broadcaster’s schedule settings, such as scheduling a vacation. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:schedule</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("schedule/settings")]
        Task PatchScheduleAsync([QueryMap] PatchScheduleArgs args);

        /// <summary> Adds a single or recurring broadcast to the broadcaster’s streaming schedule. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:schedule</c> scope. </remarks>
        /// <returns> A single <see cref="Schedule"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Post("schedule/segment")]
        Task<TwitchResponse<Schedule>> PostSegmentAsync([QueryMap] PostSegmentArgs args, [Body] PostSegmentBody body);

        /// <summary> Updates a scheduled broadcast segment. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:schedule</c> scope. </remarks>
        /// <returns> A single <see cref="Schedule"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 403 Forbidden </exception>
        /// <exception cref="MissingScopeException" />
        [Patch("schedule/segment")]
        Task<TwitchResponse<Schedule>> PatchSegmentAsync([QueryMap] ManageSegmentArgs args, [Body] PatchSegmentBody body);

        /// <summary> Updates a scheduled broadcast segment. </summary>
        /// <remarks> Requires a <see href="https://dev.twitch.tv/docs/authentication#user-access-tokens">user access token</see>
        /// with the <c>channel:manage:schedule</c> scope. </remarks>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        /// <exception cref="MissingScopeException" />
        [Delete("schedule/segment")]
        Task DeleteSegmentAsync([QueryMap] ManageSegmentArgs args);

        #endregion
        #region Search

        /// <summary> Gets the games or categories that match the specified query. </summary>
        /// <returns> A collection of <see cref="Category"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("search/categories")]
        Task<TwitchMetaResponse<Category>> GetCategoriesAsync([QueryMap] SearchCategoriesArgs args);

        /// <summary> Gets the channels that match the specified query and have streamed content within the past 6 months. </summary>
        /// <returns> A collection of <see cref="ChannelBroadcast"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized </exception>
        [Get("search/channels")]
        Task<TwitchMetaResponse<ChannelBroadcast>> GetChannelsAsync([QueryMap] SearchChannelsArgs args);

        #endregion
        #region Music

        /// <summary> Gets the Soundtrack track that the broadcaster is playing. </summary>
        /// <returns> A single <see cref="Soundtrack"/> object. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("soundtrack/current_track")]
        Task<TwitchResponse<Soundtrack>> GetCurrentTrackAsync([QueryMap] GetCurrentTrackArgs args);

        /// <summary> Gets the Soundtrack playlist’s tracks. </summary>
        /// <returns> A collection of <see cref="Track"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("soundtrack/playlist")]
        Task<TwitchMetaResponse<Track>> GetPlaylistTracksAsync([QueryMap] GetPlaylistTracksArgs args);

        /// <summary> Gets a list of Soundtrack playlists. </summary>
        /// <returns> A collection of <see cref="Track"/> objects. </returns>
        /// <exception cref="TwitchRestException"> 400 Bad Request, 401 Unauthorized, 404 Not Found </exception>
        [Get("soundtrack/playlists")]
        Task<TwitchMetaResponse<Playlist>> GetPlaylistsAsync([QueryMap] GetPlaylistsArgs args);

        #endregion
        #region Broadcasts / Streams

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
        Task<TwitchResponse<ChannelTeam>> GetTeamsAsync([QueryMap] GetChannelTeamsArgs args);

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
        Task PostWhisperAsync([QueryMap] PostWhisperArgs args, [Body] PostWhisperBody body);

        #endregion
    }
}
