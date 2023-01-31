using Itzz.Entities;
using Itzz.Enums;

namespace Itzz.DTO;

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
    public string? Route { get; set; }
    public string? Comments { get; set; }
}