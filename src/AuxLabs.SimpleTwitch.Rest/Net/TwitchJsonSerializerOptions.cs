﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
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
            options.Converters.Add(new InterfaceConverterFactory<ExtensionTransactionCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<FollowCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<RaidCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<RewardCondition, IEventCondition>());
            options.Converters.Add(new InterfaceConverterFactory<UserCondition, IEventCondition>());

            Default = options;
        }
    }
}