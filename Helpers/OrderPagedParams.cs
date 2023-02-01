using Itzz.Enums;

namespace Itzz.Helpers;

public class OrderPagedParams : PaginationParams
{
    public Priority Priority { get; set; }
    public int RouteId { get; set;}
}