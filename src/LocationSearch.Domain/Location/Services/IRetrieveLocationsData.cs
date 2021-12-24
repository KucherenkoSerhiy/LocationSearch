using System.Threading.Tasks;

namespace LocationSearch.Domain.Location.Services
{
    public interface IRetrieveLocationsData<TQ>
    {
        Task Read(TQ query);
    }
}