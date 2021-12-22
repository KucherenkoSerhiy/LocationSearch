using LocationSearch.Domain.Location.Models;
using MediatR;

namespace LocationSearch.Application.Location.Models.Queries
{
    public class RetrieveLocationsQuery: IRequest<RetrieveLocationsQuery>
    {
        public LocationQueryParams Parameters { get; set; }
    }
}