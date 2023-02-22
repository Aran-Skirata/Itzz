using AutoMapper;
using Itzz.Controllers;
using Itzz.Entities;
using Itzz.Interfaces;
using Itzz.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itzz.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
        _roleManager = roleManager;
    }


    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.UserName)) return BadRequest("Username already exists");

        var user = _mapper.Map<AppUser>(registerDto);

        user.UserName = registerDto.UserName.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);
        
        var roleResult = await _userManager.AddToRoleAsync(user, "Member");

        if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
        
        return new UserDto()
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user),
            EmployeeId = user.EmployeeId,
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        
        var user = await _userManager.Users
            .SingleOrDefaultAsync(x => x.UserName == loginDto.username.ToLower());
        if (user == null) return Unauthorized("Invalid username");

        var result = await _signInManager
            .CheckPasswordSignInAsync(user, loginDto.password, false);

        if (!result.Succeeded) return Unauthorized();

        return new UserDto()
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user),
            EmployeeId = user.EmployeeId,
        };

    }

    private async Task<Boolean> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
    
    
    
    
}