using CoolQuest.backend.DTO;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.WebAPI.Controllers
{
    [Route("questions")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly CoolQuestContex _db;
        public QuestController(CoolQuestContex contex)
        {
            _db = contex;
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> PostResultAsync(int userId, int roomId, int questionId)
        {

            if (!_db.Users.Any(x => x.Id == userId))
            {
                return NotFound();
            }

            if (!_db.Rooms.Any(x => x.Id == roomId))
            {
                return NotFound();
            }

            if (!_db.Questions.Any(x => x.Id == questionId))
            {
                return NotFound();
            }

            Completed completed = await _db.Completeds.FirstOrDefaultAsync(x => x.UserId == userId && x.RoomId == roomId && x.QuestionId == questionId);

            if (completed != null)
            {
                return BadRequest();
            }

            _db.Completeds.Add(new Completed() { UserId = userId, RoomId = roomId, QuestionId = questionId});
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
