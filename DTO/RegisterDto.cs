using System.ComponentModel.DataAnnotations;

namespace Itzz.DTO;

public class RegisterDto
{
    [Required] public string UserName { get; set; }
    
    [Required] public string EmployeeId { get; set; }
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; }
}