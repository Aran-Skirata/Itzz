namespace Itzz.Entities;

public class Route
{
    public int Id { get; set; }
    public string RecipientLoc { get; set; }
    public string StorageLoc { get; set; }
    public List<Order> Orders { get; set; }
}