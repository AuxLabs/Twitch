namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface ICharityApi
{
    public Task GetCampaignAsync();
    public Task GetCampaignDonationsAsync();
}
