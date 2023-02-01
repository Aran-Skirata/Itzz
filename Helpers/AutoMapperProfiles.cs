using AutoMapper;
using Itzz.DTO;
using Itzz.Entities;
using Route = Itzz.Entities.Route;

namespace Itzz.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Cargo, CargoDto>();
        CreateMap<CargoDto, Cargo>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<Route, RouteDto>();
        CreateMap<RouteDto, Route>();
    }
}