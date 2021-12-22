using System.Collections.Generic;

namespace LocationSearch.Application.Location.Models.Queries.Responses
{
    public class RetrieveLocationsQueryResponse
    {
        public List<Domain.Location.Models.Location> Locations { get; set; }
    }
}