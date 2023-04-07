using System.Drawing;

namespace AuxLabs.Twitch
{
    public interface IChatUser : IUser
    {
        Color? Color { get; }
    }
}
