using System.Threading.Tasks;

namespace LocationSearch.Domain.Location.Services
{
    public interface IRetrieveQueryBuilder<TP, TR>
    {
        Task<TR> Build(TP parameters);
    }
}