namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IEntitlementsApi
{
    public Task GetEntitlementsAsync();
    public Task UpdateEntitlementsAsync();
}
