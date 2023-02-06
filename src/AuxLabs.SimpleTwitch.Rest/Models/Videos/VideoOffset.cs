using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest
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
