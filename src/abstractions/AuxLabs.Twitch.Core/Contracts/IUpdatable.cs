using System.Threading.Tasks;

namespace AuxLabs.Twitch
{
    public interface IUpdatable
    {
        Task UpdateAsync();
    }
}
