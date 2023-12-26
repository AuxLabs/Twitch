namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IGamesApi
{
    public Task GetTopGamesAsync();
    public Task GetGamesAsync();
}
