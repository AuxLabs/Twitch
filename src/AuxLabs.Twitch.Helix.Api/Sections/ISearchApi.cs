namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface ISearchApi
{
    public Task SearchCategoriesAsync();
    public Task SearchChannelsAsync();
}
