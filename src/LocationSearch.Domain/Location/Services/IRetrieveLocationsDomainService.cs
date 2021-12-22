using System.Collections.Generic;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Models;

namespace LocationSearch.Domain.Location.Services
{
    public interface IRetrieveLocationsDomainService
    {
        Task<List<Models.Location>> Retrieve(LocationQueryParams parameters);
    }
}