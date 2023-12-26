namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IUsersApi
{
    public Task GetUsersAsync();
    public Task UpdateUserAsync();
    public Task GetUserBlocklistAsync();
    public Task BlockUserAsync();
    public Task UnblockUserAsync();
    public Task GetUserExtensionsAsync();
    public Task GetUserActiveExtensionsAsync();
}
