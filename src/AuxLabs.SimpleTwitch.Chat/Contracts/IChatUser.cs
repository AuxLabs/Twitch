using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public interface IChatUser : IUser
    {
        Color? Color { get; }
    }
}
