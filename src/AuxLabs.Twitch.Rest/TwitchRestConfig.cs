using AuxLabs.Twitch.Rest;

namespace AuxLabs.Twitch.Rest
{
    public class TwitchRestConfig : TwitchRestApiConfig
    {
        /// <summary> Whether the client should automatically download information about the currently authenticated user after validation. </summary>
        public bool DownloadMyInformation = true;
    }
}
