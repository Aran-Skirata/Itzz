using Itzz.Data;
using Itzz.DTO;
using Itzz.Extensions;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Controllers;

public class RouteController : BaseApiController
{
    private readonly RouteRepository _routeRepository;

    public RouteController(RouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteDto>>> GetRoutes(RoutePagedParams routePagedParams)
    {
        var routes = await _routeRepository.GetRouteAsync(routePagedParams);
        
        Response.AddPaginationHeader(routes.CurrentPage,routes.TotalPages,routes.PageSize,routes.TotalCount);

        return Ok(routes);
    }

    [HttpPost]
    public async Task<ActionResult> CreateRoute(RouteDto routeDto)
    {
        _routeRepository.AddNewRoute(routeDto);

        if (await _routeRepository.SaveAllAsync()) return NoContent();
        return BadRequest("Could not save route data");
    }
}