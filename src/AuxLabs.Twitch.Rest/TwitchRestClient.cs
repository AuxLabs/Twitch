using AuxLabs.SimpleTwitch.Rest;
using AuxLabs.Twitch.Rest.Entities;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        internal TwitchRestApiClient API { get; }

        public TwitchRestClient()
        {
            API = new TwitchRestApiClient();
        }
    }
}
