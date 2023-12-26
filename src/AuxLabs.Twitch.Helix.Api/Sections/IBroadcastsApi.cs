namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IBroadcastsApi
{
    public Task GetStreamKeyAsync();
    public Task GetBroadcastsAsync();
    public Task GetFollowedBroadcastsAsync();
    public Task CreateBroadcastMarkerAsync();
    public Task GetBroadcastMarkersAsync();
}
