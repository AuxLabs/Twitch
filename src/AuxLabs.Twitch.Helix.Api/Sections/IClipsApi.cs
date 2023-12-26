namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IClipsApi
{
    public Task CreateClipAsync();
    public Task GetClipsAsync();
}
