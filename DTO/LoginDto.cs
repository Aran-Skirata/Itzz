using System.ComponentModel.DataAnnotations;

namespace Itzz.DTO;

public class LoginDto
{
    [Required] public string username { get; set; }
    [Required] public string password { get; set; }
}