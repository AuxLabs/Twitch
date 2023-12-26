namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IAnalyticsApi
{
    Task GetExtensionAnalyticsAsync();
    Task GetGameAnalyticsAsync();
}
