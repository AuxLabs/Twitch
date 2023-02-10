using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChannelsArgs : QueryMap<string[]>
    {
        /// <summary> A collection of IDs of the broadcasters whose channel you want to get. </summary>
        /// <remarks> You may specify a maximum of 100 IDs. </remarks>
        public List<string> ChannelIds { get; set; }

        public GetChannelsArgs() { }
        public GetChannelsArgs(params string[] channelIds)
        {
            ChannelIds = channelIds.ToList();
        }
        public GetChannelsArgs(List<string> channelIds)
        {
            ChannelIds = channelIds;
        }

        public void Validate()
        {
            Require.NotNull(ChannelIds, nameof(ChannelIds));
            Require.HasAtLeast(ChannelIds, 1, nameof(ChannelIds));
            Require.HasAtMost(ChannelIds, 100, nameof(ChannelIds));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["broadcaster_id"] = ChannelIds.ToArray()
            };
        }

        public static implicit operator string[](GetChannelsArgs value) => value.ChannelIds.ToArray();
        public static implicit operator GetChannelsArgs(string[] v) => new GetChannelsArgs(v);
        public static implicit operator List<string>(GetChannelsArgs value) => value.ChannelIds;
        public static implicit operator GetChannelsArgs(List<string> v) => new GetChannelsArgs(v);
    }
}