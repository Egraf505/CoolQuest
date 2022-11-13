using CoolQuest.backend.DTO;
using CoolQuest.backend.Models;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace CoolQuest.backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly CoolQuestContex _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CoolQuestContex contex)
        {
            _logger = logger;
            _db = contex;
        }

        [HttpGet()]
        public async Task<IEnumerable<Question>> Get()
        {       

            Room room  = await _db.Rooms.FirstOrDefaultAsync();

            var questions = _db.Questions.Where(x => x.RoomId == room.Id).ToList();

            return questions;
        }        
    }
}