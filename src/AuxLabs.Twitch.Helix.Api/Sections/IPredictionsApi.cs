namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IPredictionsApi
{
    public Task GetPredictionsAsync();
    public Task CreatePredictionAsync();
    public Task EndPredictionAsync();
}
