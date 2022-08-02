namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public enum IrcMessageState
    {
        None,
        Tags,
        Prefix,
        Command,
        Parameter,
        Remainder,
        Endline
    }
}
