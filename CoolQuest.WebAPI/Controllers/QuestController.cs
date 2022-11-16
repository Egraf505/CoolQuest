using CoolQuest.backend.DTO;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.WebAPI.Controllers
{
    [Route("quest")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly CoolQuestContex _db;
        public QuestController(CoolQuestContex contex)
        {
            _db = contex;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int questionId)
        {
            Question question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == questionId);

            if (question == null)            
                return NotFound();

            List<AnswerFalse> answerFalses = _db.AnswerFalses.Where(x => x.QuestionId == question.Id).ToList();
            var type = await _db.Types.FirstOrDefaultAsync(x => x.Id == question.TypeId);
            string typeTitle = type.Title;


            QuestionDTO questionDTO = new QuestionDTO() { question = question , Title = typeTitle, answerFalses = answerFalses};

            return Ok(questionDTO);            
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
