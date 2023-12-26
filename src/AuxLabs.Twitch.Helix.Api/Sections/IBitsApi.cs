namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IBitsApi
{
    public Task GetBitsLeaderboardAsync();
    public Task GetCheermotesAsync();
    public Task GetExtensionTransactionsAsync();
}
