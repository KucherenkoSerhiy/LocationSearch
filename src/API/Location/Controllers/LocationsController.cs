using System.Threading.Tasks;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Application.Location.Models.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocationSearch.Location.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class LocationsController
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<RetrieveLocationsQueryResponse>> RetrieveLocations(RetrieveLocationsQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }
    }
}