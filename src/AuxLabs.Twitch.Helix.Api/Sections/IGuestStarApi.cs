namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IGuestStarApi
{
    public Task GetGuestStarSettingsAsync();
    public Task UpdateGuestStarSettingsAsync();
    public Task GetGuestStarSessionAsync();
    public Task CreateGuestStarSessionAsync();
    public Task EndGuestStarSessionAsync();
    public Task GetGuestStarInvitesAsync();
    public Task SendGuestStarInviteAsync();
    public Task DeleteGuestStarInviteAsync();
    public Task AssignGuestStarSlotAsync();
    public Task UpdateGuestStarSlotAsync();
}
