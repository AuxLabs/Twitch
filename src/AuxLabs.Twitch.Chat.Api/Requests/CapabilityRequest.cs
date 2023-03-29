using AuxLabs.Twitch.Chat.Api;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat.Requests
{
    public class CapabilityRequest : IrcPayload
    {
        public bool HasData { get; }

        public CapabilityRequest(bool commands, bool tags)
        {
            Command = IrcCommand.CapabilityRequest;

            var capabilities = new List<string>();
            if (commands) capabilities.Add("twitch.tv/commands");
            if (tags) capabilities.Add("twitch.tv/tags");

            if (capabilities.Count > 0)
            {
                HasData = true;
                capabilities[0] = capabilities[0].Insert(0, ":");
                Parameters = capabilities.AsReadOnly();
            }
        }
    }
}
