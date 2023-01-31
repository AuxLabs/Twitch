namespace AuxLabs.SimpleTwitch.Rest
{
    public interface IPaginated
    {
        /// <summary> The maximum number of items to return per page in the response. </summary>
        int? First { get; set; }

        /// <summary> The cursor used to get the next page of results. </summary>
        string After { get; set; }
    }
}
