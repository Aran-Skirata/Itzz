using Itzz.Entities;

namespace Itzz.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}