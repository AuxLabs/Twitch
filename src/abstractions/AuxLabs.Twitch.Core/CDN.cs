namespace AuxLabs.Twitch
{
    public static class CDN
    {
        public const string EmoteImageUrl = "https://static-cdn.jtvnw.net/emoticons/v2/{0}/{1}/{2}/{3}";

        public static string GetEmoteImageUrl(string emoteId, EmoteFormat format = EmoteFormat.Static, EmoteTheme theme = EmoteTheme.Dark, EmoteScale scale = EmoteScale.Small)
        {
            var formatValue = format.GetStringValue();
            var themeValue = theme.GetStringValue();
            var scaleValue = scale.GetStringValue();

            return string.Format(EmoteImageUrl, emoteId, formatValue, themeValue, scaleValue);
        }
    }
}
