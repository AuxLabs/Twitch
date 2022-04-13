using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestApiClient : ITwitchApi, IDisposable
    {
        private readonly ITwitchApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public string ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchRestApiClient()
            : this(TwitchConstants.BaseUrl) { }
        public TwitchRestApiClient(string baseUrl)
            : this(new HttpClient { BaseAddress = new Uri(baseUrl) }) { }
        public TwitchRestApiClient(HttpClient httpClient)
        {
            _api = new RestClient(httpClient)
            {
                RequestBodySerializer = new Net.JsonBodySerializer(),
                ResponseDeserializer = new Net.JsonResponseDeserializer(),
                RequestQueryParamSerializer = new Net.JsonQueryParamSerializer(),
            }.For<ITwitchApi>();
        }

        public void Dispose() => _api.Dispose();

        public Task<TwitchResponse<Commercial>> PostCommercialAsync([Body] PostChannelCommercialParams args)
            => _api.PostCommercialAsync(args);

        public Task<TwitchResponse<Analytic>> GetExtensionAnalyticsAsync([Query] GetExtensionAnalyticsParams args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<Analytic>> GetGameAnalyticsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<Cheermote>> GetCheermotesasync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<Channel> GetChannelAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task ModifyChannelAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateRewardsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRewardAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetRewardsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRewardRedemptionAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> ModifyRewardAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> ModifyRewardRedemptionAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetChannelEmotesAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetGlobalEmotesAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetEmoteSetsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetChannelBadgesAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetGlobalBadgesAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> GetChatSettingsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<object>> ModifyChatSettingsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateClipAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetClipsAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetCodeStatusAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetDropsStatusAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> ModifyDropsStatusAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        public Task<object> RedeemCodeAsync([Query] object args)
        {
            throw new NotImplementedException();
        }

        // extensions
        // eventsub
        // games
        // goals
        // hype train
        // moderations
        // polls
        // predictions
        // schedule
        // search
        // music
        // streams
        // subscriptions
        // tags
        // teams
        // users

        public Task<TwitchResponse<User>> GetUsersAsync([Query] GetUsersParams args)
            => _api.GetUsersAsync(args);
    }
}
