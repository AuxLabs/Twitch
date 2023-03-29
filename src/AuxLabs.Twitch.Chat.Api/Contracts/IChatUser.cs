using System.Drawing;

namespace AuxLabs.Twitch.Chat
{
    public interface IChatUser : IUser
    {
        Color? Color { get; }
    }
}
