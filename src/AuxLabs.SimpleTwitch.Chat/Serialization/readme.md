### Workflow

####Full Message:
`@badge-info=;badges=broadcaster/1;client-nonce=997dcf443c31e258c1d32a8da47b6936;color=#0000FF;display-name=abc;emotes=;first-msg=0;flags=0-6:S.7;id=eb24e920-8065-492a-8aea-266a00fc5126;mod=0;room-id=713936733;subscriber=0;tmi-sent-ts=1642786203573;turbo=0;user-id=713936733;user-type= :abc!abc@abc.tmi.twitch.tv PRIVMSG #xyz :HeyGuys`

####Message Parts:
#####Tags
`@` - Message has tags
`name` - Name of tag
`=` - Start of value
`` - Tag values can be empty
`value` - Value of tag
`key/value` - Alternate tag value for dictionary
`;` - End of tag
` ` - End of all tags

#####Prefix
`:` - Message has a prefix
`value` - Nickname
`!` - Start of username
`value` - Username
`@` - Start of host
`value` - Host
` ` - End of prefix

#####Command
`value` - Command value
` ` - Value separator
`$` - Server indicator
`#` - Channel indicator
`value` - Name of server or channel
` ` - End of command

##### Parameters
`:` - Start of parameters
All remaining values are parameters, space deliminated.