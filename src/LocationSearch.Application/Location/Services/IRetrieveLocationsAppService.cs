using System.Collections.Generic;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Models;

namespace LocationSearch.Application.Location.Services
{
    public interface IRetrieveLocationsAppService
    {
        Task<List<Domain.Location.Models.Location>> Retrieve(LocationQueryParams parameters);
    }
}