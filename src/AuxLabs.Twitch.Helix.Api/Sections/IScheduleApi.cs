namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IScheduleApi
{
    public Task GetScheduleAsync();
    public Task UpdateScheduleAsync();
    public Task CreateScheduleSegmentAsync();
    public Task UpdateScheduleSegmentAsync();
    public Task DeleteScheduleSegmentAsync();
}
