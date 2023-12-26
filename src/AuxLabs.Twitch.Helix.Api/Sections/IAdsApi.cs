namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IAdsApi
{
    public Task StartAdAsync();
    public Task GetAdScheduleAsync();
    public Task SnoozeNextAdAsync();
}
