using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Collections;
using LocationSearch.Domain.Location.Models;

namespace LocationSearch.Domain.Location.Services.Impl
{
    public class RetrieveLocationsDomainService: IRetrieveLocationsDomainService
    {
        private readonly IRetrieveLocationsData<LocationQueryParams> _locationsData;
        private readonly ILocationCollection _locationCollection;

        public RetrieveLocationsDomainService(
            IRetrieveLocationsData<LocationQueryParams> locationsData,
            ILocationCollection locationCollection)
        {
            _locationsData = locationsData;
            _locationCollection = locationCollection;
        }
        
        public async Task<List<Models.Location>> Retrieve(LocationQueryParams parameters)
        {
            await _locationsData.Read(parameters);
            return _locationCollection.Values.Values.ToList();
        }
    }
}