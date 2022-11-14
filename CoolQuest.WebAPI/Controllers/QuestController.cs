using CoolQuest.backend.DTO;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly CoolQuestContex _db;
        public QuestController(CoolQuestContex contex)
        {
            _db = contex;
        }

        [HttpGet("{Roomid}")]
        public async Task<IActionResult> GetAsync(int id)
        {

            List<QuestionDTO> questionsDTO = new();

            var questions = await _db.Questions.Where(x => x.RoomId == id).ToListAsync();

            var answerFalsesDb = await _db.AnswerFalses.ToListAsync();

            if (questions != null)
            {               
                return Ok(questions);
            }       

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostResultAsync(Completed completed)
        {
            if (_db.Completeds.Contains(completed))
            {
                return BadRequest();
            }

            _db.Completeds.Add(completed);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
