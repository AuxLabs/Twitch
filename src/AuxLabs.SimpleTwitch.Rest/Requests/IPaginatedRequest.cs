namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> Indicates that a request can be paginated. </summary>
    public interface IPaginatedRequest
    {
        /// <summary> The maximum number of items to return per page in the response. </summary>
        int? First { get; set; }

        /// <summary> The cursor used to get the previous page of results. </summary>
        string Before { get; set; }

        /// <summary> The cursor used to get the next page of results. </summary>
        string After { get; set; }
    }
}
