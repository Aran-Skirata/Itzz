using Itzz.Enums;

namespace Itzz.Entities;

public class Order
{
    public int Id { get; set; }
    public Priority Priority { get; set; }
    public string? Uuid { get; set; }
    public DateTime DueTime { get; set; }
    public int Verification { get; set; }
    public string? Description { get; set; }
    public string? TransportMeans { get; set; }
    public string? ExecutionMethod { get; set; }
    public string? Comments { get; set; }
    public ICollection<Cargo> Cargoes { get; set; }
    public int RouteId { get; set; }
    public Route Route { get; set; }
}