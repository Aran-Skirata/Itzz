using AutoMapper;
using AutoMapper.QueryableExtensions;
using Itzz.DTO;
using Itzz.Entities;
using Itzz.Interfaces;
using MedFiszkiApi.Data;
using MedFiszkiApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Itzz.Data;

public class OrderRepository : IOrderRepository
{
    private readonly Mapper _mapper;
    private readonly DataContext _dataContext;

    public OrderRepository(Mapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<PagedList<OrderDto>> GetOrderAsync(OrderPagedParams orderPagedParams)
    {
        var query = _dataContext.Orders.Include(o => o.Route).Include(o => o.Cargoes).AsQueryable();

        query = query.Where(o => o.RouteId == orderPagedParams.RouteId);
        query = query.Where(o => o.Priority == orderPagedParams.Priority);

        return await PagedList<OrderDto>.CreateAsync(
            query.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            orderPagedParams.PageNumber,
            orderPagedParams.PageSize);

    }

    public void AddNewOrder(OrderDto orderDto)
    {
        _dataContext.Orders.Add(_mapper.Map<Order>(orderDto));
    }

    public Task<ActionResult> UpdateOrder()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> DeleteOrder()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}