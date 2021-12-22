using System.Threading.Tasks;

namespace LocationSearch.Domain.Location.Services
{
    public interface IRetrieveQueryRunner<TQ, TR>
    {
        Task<TR> Run(TQ query);
    }
}