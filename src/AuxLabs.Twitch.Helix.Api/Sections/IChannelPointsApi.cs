namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IChannelPointsApi
{
    public Task CreateRewardAsync();
    public Task DeleteRewardAsync();
    public Task GetRewardsAsync();
    public Task GetRedemptionsAsync();
    public Task UpdateRewardAsync();
    public Task UpdateRedemptionStatusAsync();
}
