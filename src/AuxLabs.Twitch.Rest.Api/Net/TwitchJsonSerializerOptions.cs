using AuxLabs.Twitch.Rest.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Api
{
    public static class TwitchJsonSerializerOptions
    {
        public static JsonSerializerOptions Default { get; }

        static TwitchJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            };

            options.Converters.Add(new RFCDateTimeConverter());
            options.Converters.Add(new CultureInfoConverter());
            options.Converters.Add(new JsonStringEnumMemberConverter());
            options.Converters.Add(new InterfaceConverterFactory<AuthorizationCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<BroadcasterCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<DropEntitlementCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<ExtensionCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<ModeratorCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<RaidCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<RewardCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<UserCondition, IEventCondition>());

            Default = options;
        }
    }
}
