using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoolQuest.WebAPI.Controllers
{
    [Route("/token")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CoolQuestContex _db;
        public AccountController(CoolQuestContex contex)
        {
            _db = contex;
        }

        [HttpPost()]
        public async Task<IActionResult> Token(string username, string password)
        {
            var identity = await GetIdentityAsync(username, password);
            if (identity == null)
                return BadRequest(new { errorText = "Invalid username or password." });

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                id = _db.Users.FirstOrDefault(x => x.Email == identity.Name)!.Id
            };

            return Ok(response);
        }

        // Добавить пользователя
        [HttpPost("/userAdd")]
        public async Task<IActionResult> AddUserAsync(string name, string surname, string email, string password)
        {
            try
            {
                if (_db.Users.Any(x => x.Email == email))
                {
                    return BadRequest(new { errorText = "User is exit" });
                }

                User user = new User() { Name = name, SurName = surname, Email = email, Password = password };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string email, string password)
        {
            User user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (user == null)
                return null;

            var claims = new List<Claim>() { 
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}

