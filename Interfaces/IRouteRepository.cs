using Itzz.DTO;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Interfaces;

public interface IRouteRepository
{
    Task<PagedList<RouteDto>> GetRouteAsync(RoutePagedParams routePagedParams);
    void AddNewRoute(RouteDto routeDto);
    Task<ActionResult> UpdateRoute();
    Task<ActionResult> DeleteRoute();
    Task<bool> SaveAllAsync();
}