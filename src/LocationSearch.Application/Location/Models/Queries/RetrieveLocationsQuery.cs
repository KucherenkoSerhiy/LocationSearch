using LocationSearch.Application.Location.Models.Queries.Responses;
using LocationSearch.Domain.Location.Models;
using MediatR;

namespace LocationSearch.Application.Location.Models.Queries
{
    public class RetrieveLocationsQuery: IRequest<RetrieveLocationsQueryResponse>
    {
        public LocationQueryParams Parameters { get; set; }
    }
}