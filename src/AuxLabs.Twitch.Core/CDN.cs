namespace AuxLabs.Twitch
{
    public static class CDN
    {
        public static string EmoteImageUrl => TwitchConstants.EmoteImageUrl;
        public static string StreamPreviewImageUrl => TwitchConstants.StreamPreviewImageUrl;

        public static string GetEmoteImageUrl(string emoteId, EmoteFormat format = EmoteFormat.Static, EmoteTheme theme = EmoteTheme.Dark, EmoteScale scale = EmoteScale.Small)
        {
            var formatValue = format.GetStringValue();
            var themeValue = theme.GetStringValue();
            var scaleValue = scale.GetStringValue();

            return string.Format(EmoteImageUrl, emoteId, formatValue, themeValue, scaleValue);
        }

        public static string GetStreamPreviewImageUrl(string userName, int width = 320, int height = 180)
            => string.Format(StreamPreviewImageUrl, userName, width, height);
    }
}
