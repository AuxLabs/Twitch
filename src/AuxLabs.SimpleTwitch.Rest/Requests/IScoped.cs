namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public interface IScoped
    {
        public static string[] Scopes { get; set; } = new string[0];
    }
}
