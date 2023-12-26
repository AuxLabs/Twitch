using AuxLabs.Twitch.Helix.Api.Sections;

namespace AuxLabs.Twitch.Helix.Api;
public interface IApi : 
    IAdsApi, IAnalyticsApi, IBitsApi, IBroadcastsApi, IChannelPointsApi,
    IChannelsApi, ICharityApi, IChatApi, IClipsApi, IEntitlementsApi,
    IEventSubApi, IGamesApi, IGoalsApi, IGuestStarApi, IHypeTrainApi,
    IModerationApi, IPollsApi, IPredictionsApi, IRaidsApi, IScheduleApi,
    ISearchApi, ISubscriptionsApi, ITeamsApi, IUsersApi, IVideosApi
{
    public string Authorization { get; init; }
    public string ClientId { get; init; }
}
