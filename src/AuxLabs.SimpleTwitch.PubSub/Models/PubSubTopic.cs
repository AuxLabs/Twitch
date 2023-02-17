using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public readonly struct PubSubTopic
    {
        public PubSubTopicType Type { get; }
        public IReadOnlyCollection<string> Ids { get; }

        public PubSubTopic(string topic)
        {
            var parts = topic.Split('.');
            Type = EnumHelper.GetEnumValue<PubSubTopicType>(parts[0]);
            Ids = parts.Skip(1).ToImmutableArray();
        }

        public override string ToString()       // topic.id.id
            => string.Join('.', EnumHelper.GetStringValue(Type), Ids);
    }
}
