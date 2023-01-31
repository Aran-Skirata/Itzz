using System.Xml;
using Itzz.Entities;
using Microsoft.EntityFrameworkCore;
using Route = Itzz.Entities.Route;

namespace MedFiszkiApi.Data;

public class DataContext : DbContext
{
    
    public DbSet<Cargo> Cargoes{ get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Route> Routes { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    

}