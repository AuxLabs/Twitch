namespace AuxLabs.Twitch
{
    public static class CDN
    {
        public static string GetEmoteImageUrl(string emoteId, EmoteFormat format = EmoteFormat.Static, EmoteTheme theme = EmoteTheme.Dark, EmoteScale scale = EmoteScale.Small)
        {
            var formatValue = format.GetStringValue();
            var themeValue = theme.GetStringValue();
            var scaleValue = scale.GetStringValue();

            return string.Format(TwitchConstants.EmoteImageUrl, emoteId, formatValue, themeValue, scaleValue);
        }
    }
}
