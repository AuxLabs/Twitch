using Newtonsoft.Json;

namespace AuxLabs.Twitch.Rest.Models
{
    public readonly struct VideoOffset
    {
        public int Duration { get; }
        public int Offset { get; }

        [JsonConstructor]
        public VideoOffset(int duration, int offset) 
            => (Duration, Offset) = (duration, offset);
    }
}
