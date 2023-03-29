using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetTeamArgs : QueryMap
    {
        /// <summary> The name of the team to get. </summary>
        public string Id { get; set; }

        /// <summary> The ID of the team to get. </summary>
        public string Name { get; set; }

        public void Validate()
        {
            Require.Exclusive(new object[] { Id, Name }, new[] { nameof(Id), nameof(Name) });
            Require.NotEmptyOrWhitespace(Id, nameof(Id));
            Require.NotEmptyOrWhitespace(Name, nameof(Name));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (Id != null)
                map["id"] = Id;
            if (Name != null)
                map["name"] = Name;

            return map;
        }
    }
}
