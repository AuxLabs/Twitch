namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IChatApi
{
    public Task GetChattersAsync();
    public Task GetEmotesAsync();
    public Task GetGlobalEmotesAsync();
    public Task GetEmoteSetsAsync();
    public Task GetBadgesAsync();
    public Task GetGlobalBadgesAsync();
    public Task GetChatSettingsAsync();
    public Task UpdateChatSettingsAsync();
    public Task SendAnnouncementAsync();
    public Task SendShoutoutAsync();
    public Task GetUserColorAsync();
    public Task UpdateUserColorAsync();
}
