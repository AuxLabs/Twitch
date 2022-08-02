namespace AuxLabs.SimpleTwitch
{
    public class WebSocketClosedException : Exception
    {
        public int CloseCode { get; }
        public string? Reason { get; } = null;

        public WebSocketClosedException(int closeCode, string? reason = null)
            : base($"The server sent close {closeCode}{(reason != null ? $": \"{reason}\"" : "")}")
        {
            CloseCode = closeCode;
            Reason = reason;
        }
    }
}
