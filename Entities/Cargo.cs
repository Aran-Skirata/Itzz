namespace Itzz.Entities;

public class Cargo
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string StorageName { get; set; }
    public string StorageType { get; set; }
    public ICollection<Order> Orders { get; set; }
}