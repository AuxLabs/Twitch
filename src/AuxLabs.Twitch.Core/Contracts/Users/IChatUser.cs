using System.Drawing;

namespace AuxLabs.Twitch
{
    public interface IChatUser : ISimpleUser
    {
        Color? Color { get; }
    }
}
