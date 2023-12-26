namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface ITeamsApi
{
    public Task GetChannelTeamsAsync();
    public Task GetTeamsAsync();
}
