using AutoMapper;
using AutoMapper.QueryableExtensions;
using Itzz.DTO;
using Itzz.Entities;
using Itzz.Interfaces;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itzz.Data;

public class OrderRepository : IOrderRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public OrderRepository(IMapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<PagedList<OrderDto>> GetOrderAsync(OrderPagedParams orderPagedParams)
    {
        var query = _dataContext.Orders.Include(o => o.Route).Include(o => o.Cargoes).AsQueryable();

        return await PagedList<OrderDto>.CreateAsync(
            query.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            orderPagedParams.PageNumber,
            orderPagedParams.PageSize);

    }

    public void AddNewOrder(OrderDto orderDto)
    {
        _dataContext.Orders.Add(_mapper.Map<Order>(orderDto));
    }

    public async Task<IEnumerable<OrderEventDto>> GetOrderEventsAsync()
    {
        return await _dataContext.Orders.ProjectTo<OrderEventDto>(_mapper.ConfigurationProvider).ToListAsync();

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