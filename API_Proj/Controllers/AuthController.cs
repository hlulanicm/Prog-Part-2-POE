using API_proj.Data;
using API_proj.Models;
using API_Proj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AuthController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (dto.Role != "Organiser" && dto.Role != "Participant")
                return BadRequest("Role must be 'Organiser' or 'Participant'.");

            var email = dto.Email.Trim().ToLower();

            if (await _context.Users.AnyAsync(u => u.Email == email))
                return BadRequest("That email is already registered.");

            var user = new User
            {
                UserName = dto.UserName,
                UserSurname = dto.UserSurname,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Never return PasswordHash
            return Ok(new
            {
                user.UserID,
                user.UserName,
                user.UserSurname,
                user.Email,
                user.Role
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var email = dto.Email.Trim().ToLower();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return Ok(new { user.UserID, user.UserName, user.Role });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logged out.");
        }
    }
}