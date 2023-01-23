namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class BitsBadgeTierTags : UserNoticeTags
    {
        /// <summary>
        /// The tier of the Bits badge the user just earned.
        /// </summary>
        public int BitsThreshold { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-threshold"] = BitsThreshold.ToString();
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-threshold", out string str))
                BitsThreshold = int.Parse(str);
        }
    }
}
