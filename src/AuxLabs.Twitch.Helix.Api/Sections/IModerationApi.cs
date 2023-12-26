namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IModerationApi
{
    public Task GetAutomodStatusAsync();
    public Task ManageAutomodMessagesAsync();
    public Task GetAutomodSettingsAsync();
    public Task UpdateAutomodSettingsAsync();
    public Task GetBannedUsersAsync();
    public Task BanUserAsync();
    public Task UnbanUserAsync();
    public Task GetBlockedTermsAsync();
    public Task AddBlockedTermAsync();
    public Task RemoveBlockedTermAsync();
    public Task DeleteMessageAsync();
    public Task GetModeratorsAsync();
    public Task AddModeratorAsync();
    public Task RemoveModeratorAsync();
    public Task GetVipsAsync();
    public Task AddVipAsync();
    public Task RemoveVipAsync();
    public Task UpdateShieldModeStatusAsync();
    public Task GetShieldModeStatusAsync();
}
