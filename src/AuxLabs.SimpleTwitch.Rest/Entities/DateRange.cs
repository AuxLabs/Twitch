using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public struct DateRange
    {
        [JsonProperty("started_at")]
        public DateTime StartedAt { get; }
        [JsonProperty("ended_at")]
        public DateTime EndedAt { get; }

        public DateRange(DateTime startedAt, DateTime endedAt)
        {
            StartedAt = startedAt;
            EndedAt = endedAt;
        }
    }
}
