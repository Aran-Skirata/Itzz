using Itzz.DTO;
using Itzz.Interfaces;
using Itzz.Extensions;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders([FromQuery]OrderPagedParams orderPagedParams)
    {
        var orders = await _orderRepository.GetOrderAsync(orderPagedParams);
        
        Response.AddPaginationHeader(orders.CurrentPage,orders.TotalPages,orders.PageSize,orders.TotalCount);

        return Ok(orders);
    }

    [HttpGet("events")]
    public async Task<ActionResult<IEnumerable<OrderEventDto>>> GetOrderEvents()
    {
        var orderEvents = await _orderRepository.GetOrderEventsAsync();
        return Ok(orderEvents);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderDto orderDto)
    {
        _orderRepository.AddNewOrder(orderDto);

        if (await _orderRepository.SaveAllAsync()) return NoContent();
        return BadRequest("Could not save order data");

    }
}