using System.Threading.Tasks;

namespace AuxLabs.Twitch
{
    public interface IDeletable
    {
        Task DeleteAsync();
    }
}
