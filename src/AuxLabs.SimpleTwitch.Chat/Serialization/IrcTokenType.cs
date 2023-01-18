namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public enum IrcTokenType
    {
        None = 0,

        TagIndicator,               // @, precedes first tag key
        TagKeyValueSeparator,       // =
        TagKeyValueEnd,             // ;
        TagEscapedSpace,            // \s
        TagEnd,                     // "space char"

        PrefixIndicator,            // :, precedes nickname
        PrefixUsernameIndicator,    // !
        PrefixHostIndicator,        // @
        PrefixEnd,                  // "space char"

        CommandEnd,                 // Next "space char" after prefix end

        ServerIndicator,            // $, twitch doesn't use this
        ChannelIndicator,           // #, read to "space char"
        ParameterIndicator,         // :, read to end of message
        Remainder                   // All end of message text
    }
}
