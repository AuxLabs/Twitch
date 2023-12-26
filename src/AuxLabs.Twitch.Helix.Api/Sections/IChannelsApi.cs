namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IChannelsApi
{
    public Task GetChannelAsync();
    public Task GetEditorsAsync();
    public Task GetFollowsAsync();
    public Task GetFollowersAsync();
}
