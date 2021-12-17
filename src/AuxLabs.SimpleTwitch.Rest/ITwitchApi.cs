using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "Auxlabs (https://github.com/AuxLabs/SimpleTwitch)")]
    internal interface ITwitchApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Post("channels/commercial")]
        Task<Commercial> PostCommercialAsync([Body]PostChannelCommercialParams args);

        [Get("analytics/extensions")]
        Task<IEnumerable<Analytic>> GetExtensionAnalyticsAsync([Query]object args);
        [Get("analytics/games")]
        Task<IEnumerable<Analytic>> GetGameAnalyticsAsync([Query]object args);

        [Get("bits/leaderboard")]
        Task<IEnumerable<BitsUser>> GetBitsLeaderboardAsync([Query]object args);
        [Get("bits/cheermotes")]
        Task<IEnumerable<Cheermote>> GetCheermotesasync([Query] object args);

        [Get("extensions/transactions")]
        Task<IEnumerable<ExtensionTransaction>> GetExtensionTransactionAsync([Query]object args);

        [Get("channels")]
        Task<Channel> GetChannelAsync([Query]object args);
        [Patch("channels")]
        Task ModifyChannelAsync([Query] object args);
        [Get("channels/editors")]
        Task<IEnumerable<ChannelEditor>> GetChannelEditorsAsync([Query] object args);

        [Post("channel_points/custom_rewards")]
        Task<object> CreateRewardsAsync([Query]object args);
        [Delete("channel_points/custom_rewards")]
        Task DeleteRewardAsync([Query] object args);
        [Get("channel_points/custom_rewards")]
        Task<IEnumerable<object>> GetRewardsAsync([Query] object args);
        [Get("channel_points/custom_rewards/redemptions")]
        Task<object> GetRewardRedemptionAsync([Query]object args);
        [Patch("channel_points/custom_rewards")]
        Task<object> ModifyRewardAsync([Query] object args);
        [Patch("channel_points/custom_rewards/redemptions")]
        Task<object> ModifyRewardRedemptionAsync([Query] object args);

        [Get("chat/emotes")]
        Task<IEnumerable<object>> GetChannelEmotesAsync([Query]object args);
        [Get("chat/emotes/global")]
        Task<IEnumerable<object>> GetGlobalEmotesAsync([Query]object args);
        [Get("chat/emotes/set")]
        Task<IEnumerable<object>> GetEmoteSetsAsync([Query]object args);
        [Get("chat/badges")]
        Task<IEnumerable<object>> GetChannelBadgesAsync([Query]object args);
        [Get("chat/badges/global")]
        Task<IEnumerable<object>> GetGlobalBadgesAsync([Query]object args);
        [Get("chat/settings")]
        Task<IEnumerable<object>> GetChatSettingsAsync([Query]object args);
        [Patch("chat/settings")]
        Task<IEnumerable<object>> ModifyChatSettingsAsync([Query]object args);

        [Post("clips")]
        Task<object> CreateClipAsync([Query] object args);
        [Get("clips")]
        Task<object> GetClipsAsync([Query] object args);

        [Get("entitlements/codes")]
        Task<object> GetCodeStatusAsync([Query] object args);
        [Get("entitlements/drops")]
        Task<object> GetDropsStatusAsync([Query] object args);
        [Patch("entitlements/drops")]
        Task<object> ModifyDropsStatusAsync([Query] object args);
        [Post("entitlements/codes")]
        Task<object> RedeemCodeAsync([Query] object args);
    }
}
