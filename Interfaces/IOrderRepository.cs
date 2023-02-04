using Itzz.DTO;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Interfaces;

public interface IOrderRepository
{
    Task<PagedList<OrderDto>> GetOrderAsync(OrderPagedParams orderPagedParams);
    void AddNewOrder(OrderDto orderDto);
    Task<IEnumerable<OrderEventDto>> GetOrderEventsAsync();
    Task<ActionResult> DeleteOrder();
    Task<bool> SaveAllAsync();
    
}