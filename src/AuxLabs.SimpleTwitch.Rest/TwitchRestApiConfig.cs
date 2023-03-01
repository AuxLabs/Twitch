namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestApiConfig
    {
        /// <summary>  </summary>
        public string ClientId { get; set; }

        /// <summary>  </summary>
        public string ClientSecret { get; set; }

        /// <summary> Should the client attempt to auto refresh tokens. </summary>
        public bool ShouldAutoRefresh { get; set; } = true;
    }
}
