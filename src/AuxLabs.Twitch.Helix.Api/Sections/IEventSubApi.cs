namespace AuxLabs.Twitch.Helix.Api.Sections;

public interface IEventSubApi
{
    public Task CreateEventSubscriptionAsync();
    public Task DeleteEventSubscriptionAsync();
    public Task GetEventSubscriptionsAsync();
}
