using Itzz.Enums;

namespace MedFiszkiApi.Helpers;

public class OrderPagedParams : PaginationParams
{
    public Priority Priority { get; set; }
    public int RouteId { get; set;}
}