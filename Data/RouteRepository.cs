using AutoMapper;
using AutoMapper.QueryableExtensions;
using Itzz.DTO;
using Itzz.Entities;
using Itzz.Interfaces;
using Itzz.Data;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Route = Itzz.Entities.Route;

namespace Itzz.Data;

public class RouteRepository : IRouteRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public RouteRepository(IMapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<PagedList<RouteDto>> GetRouteAsync(RoutePagedParams routePagedParams)
    {
       var query = _dataContext.Routes.Include(r => r.Orders).AsQueryable();

       query = query.Where(r => r.Id == routePagedParams.Id);

       return await PagedList<RouteDto>.CreateAsync(
           query.ProjectTo<RouteDto>(_mapper.ConfigurationProvider).AsNoTracking(),
           routePagedParams.PageNumber,
           routePagedParams.PageSize);


    }

    public void AddNewRoute(RouteDto routeDto)
    {
        _dataContext.Routes.Add(_mapper.Map<Route>(routeDto));
    }

    public Task<ActionResult> UpdateRoute()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> DeleteRoute()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}