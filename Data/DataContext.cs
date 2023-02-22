using System.Xml;
using Itzz.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route = Itzz.Entities.Route;

namespace Itzz.Data;

public class DataContext : IdentityDbContext<AppUser,AppRole, int, IdentityUserClaim<int>,
    AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{

    public DbSet<Cargo> Cargoes{ get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Route> Routes { get; set; }


    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasMany(ur => ur.AppUserRoles)
            .WithOne(u => u.AppUser)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(ur => ur.AppUserRoles)
            .WithOne(u => u.AppRole)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }
}
