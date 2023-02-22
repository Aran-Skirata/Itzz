using Microsoft.AspNetCore.Identity;

namespace Itzz.Entities;

public class AppUser : IdentityUser<int>
{
    public string EmployeeId { get; set; }
    public ICollection<AppUserRole> AppUserRoles { get; set; }

}