using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchScheduleArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:schedule" };

        /// <summary> The ID of the broadcaster whose schedule settings you want to update. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Indicates whether the broadcaster has scheduled a vacation. </summary>
        public bool? IsVacationEnabled { get; set; }

        /// <summary> The UTC date and time of when the broadcaster’s vacation starts. </summary>
        public DateTime? VacationStartsAt { get; set; }

        /// <summary> The UTC date and time of when the broadcaster’s vacation ends. </summary>
        public DateTime? VacationEndsAt { get; set; }

        /// <summary> The time zone that the broadcaster broadcasts from. </summary>
        /// <remarks> Specify the time zone using <see href="https://www.iana.org/time-zones">IANA time zone database</see> format </remarks>
        public string Timezone { get; set; } = null;

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotEmptyOrWhitespace(Timezone, nameof(Timezone));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (IsVacationEnabled != null)
                map["is_vacation_enabled"] = IsVacationEnabled.ToString().ToLower();
            if (VacationStartsAt != null)
                map["vacation_start_time"] = XmlConvert.ToString(VacationStartsAt.Value, XmlDateTimeSerializationMode.Utc);
            if (VacationEndsAt != null)
                map["vacation_end_time"] = XmlConvert.ToString(VacationEndsAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Timezone != null)
                map["timezone"] = Timezone;

            return map;
        }
    }
}
