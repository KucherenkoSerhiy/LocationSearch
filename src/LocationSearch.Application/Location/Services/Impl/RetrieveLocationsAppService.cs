using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Patterns;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;

namespace LocationSearch.Application.Location.Services.Impl
{
    public class RetrieveLocationsAppService : IRetrieveLocationsAppService
    {
        private readonly IRetrieveLocationsDomainService _retrieveLocationsDomainService;
        private readonly IEnumerable<IRequestValidator<LocationQueryParams>> _validators;

        public RetrieveLocationsAppService(
            IRetrieveLocationsDomainService retrieveLocationsDomainService,
            IEnumerable<IRequestValidator<LocationQueryParams>> validators)
        {
            _retrieveLocationsDomainService = retrieveLocationsDomainService;
            _validators = validators;
        }
        
        public async Task<List<Domain.Location.Models.Location>> Retrieve(LocationQueryParams parameters)
        {
            foreach (var validator in _validators)
            {
                validator.Validate(parameters);
            }

            var locations = await _retrieveLocationsDomainService.Retrieve(parameters);

            return locations;
        }
    }
}