using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
                return BadRequest(new { errorText = "Invalid username or password." });

            return Ok();
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            User user = _db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

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
