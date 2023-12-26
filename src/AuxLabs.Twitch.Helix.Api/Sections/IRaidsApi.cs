namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IRaidsApi
{
    public Task StartRaidAsync();
    public Task CancelRaidAsync();
}
