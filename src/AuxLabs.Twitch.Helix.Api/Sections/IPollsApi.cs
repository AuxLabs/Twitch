namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IPollsApi
{
    public Task GetPollsAsync();
    public Task CreatePollAsync();
    public Task EndPollAsync();
}
