using AuxLabs.Twitch.EventSub.Api;
using AuxLabs.Twitch.Rest;

namespace AuxLabs.Twitch.EventSub
{
    public class TwitchEventSubConfig : TwitchEventSubApiConfig
    {
        /// <summary> Configuration for the internal rest client </summary>
        public TwitchRestConfig RestConfig { get; set; }

    }
}
