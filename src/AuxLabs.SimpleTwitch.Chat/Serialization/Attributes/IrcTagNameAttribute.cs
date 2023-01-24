namespace AuxLabs.SimpleTwitch.Chat
{
    [AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false)]
    public class IrcTagNameAttribute : Attribute
    {
        public IrcTagNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
