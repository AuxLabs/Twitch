// https://github.com/discord-net/Discord.Net/blob/75ae48830e256086be58e25e1534358572d9dd7a/src/Discord.Net.Core/Utils/Paging/PageInfo.cs

namespace AuxLabs.Twitch
{
    internal class PageInfo
    {
        public int Page { get; set; }
        public int? Count { get; set; }
        public int PageSize { get; set; }
        public int? Remaining { get; set; }

        public string Cursor { get; set; }

        internal PageInfo(int? count, int pageSize)
        {
            Page = 1;
            Count = count;
            Remaining = count;
            PageSize = pageSize;

            if (Count != null && Count.Value < PageSize)
                PageSize = Count.Value;
        }
    }
}
