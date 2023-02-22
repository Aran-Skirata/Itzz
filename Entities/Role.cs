using Microsoft.AspNetCore.Identity;

namespace Itzz.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> AppUserRoles { get; set; }
}