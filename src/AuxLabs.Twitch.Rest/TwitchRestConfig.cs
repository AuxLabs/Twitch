using AuxLabs.Twitch.Rest;
using AuxLabs.Twitch.Rest.Api;

namespace AuxLabs.Twitch.Rest
{
    public class TwitchRestConfig : TwitchRestApiConfig
    {
        /// <summary> Whether the client should automatically download information about the currently authenticated user after validation. </summary>
        public bool DownloadMyInformation = true;
    }
}
