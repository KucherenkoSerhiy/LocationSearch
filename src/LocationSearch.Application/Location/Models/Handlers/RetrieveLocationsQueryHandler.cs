using System.Threading;
using System.Threading.Tasks;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Application.Location.Models.Queries.Responses;
using LocationSearch.Application.Location.Models.Services;
using MediatR;

namespace LocationSearch.Application.Location.Models.Handlers
{
    public class RetrieveLocationsQueryHandler : IRequestHandler<RetrieveLocationsQuery, RetrieveLocationsQueryResponse>
    {
        private readonly IRetrieveLocationsAppService _retrieveLocationsAppService;

        public RetrieveLocationsQueryHandler(IRetrieveLocationsAppService retrieveLocationsAppService)
        {
            _retrieveLocationsAppService = retrieveLocationsAppService;
        }

        public async Task<RetrieveLocationsQueryResponse> Handle(RetrieveLocationsQuery request,
            CancellationToken cancellationToken)
        {
            var response = new RetrieveLocationsQueryResponse
            {
                Locations = await _retrieveLocationsAppService.Retrieve(request.Parameters)
            };
            return response;
        }
    }
}