using CoolQuest.backend.DTO;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.WebAPI.Controllers
{
    [Authorize]
    [Route("quest")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly CoolQuestContex _db;
        public QuestController(CoolQuestContex contex)
        {
            _db = contex;
        }


        // получить вопрос по id
        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetAsync(int questionId)
        {
            Question question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == questionId);

            if (question == null)
                return NotFound(new { errorText = "Question not found" });

            List<AnswerFalse> answerFalses = _db.AnswerFalses.Where(x => x.QuestionId == question.Id).ToList();
            var type = await _db.Types.FirstOrDefaultAsync(x => x.Id == question.TypeId);
            var room = await _db.Rooms.FirstOrDefaultAsync(x => x.Id == question.RoomId);

            QuestionDTO questionDTO = new() { Question = question, AnswerFalses = answerFalses };

            return Ok(questionDTO);
        }

        // вернуть все вопросы с комнаты
        [HttpGet("/questions{roomId}")]
        public async Task<IActionResult> GetQuestionsAsync(int roomId)
        {
            if (!await _db.Rooms.AnyAsync(x => x.Id == roomId))
            {
                return NotFound(new { errorText = "Room not found" } );
            }

            var questions = await _db.Questions.Where(x => x.RoomId == roomId).ToListAsync();

            return Ok(questions);
        }

        // Пройдено ли задание пользователем
        [HttpGet()]
        public async Task<IActionResult> GetAsync(int questionsId, int userId)
        {
            Completed completed = await _db.Completeds.FirstOrDefaultAsync(x => x.UserId == userId && x.QuestionId == questionsId);

            if (completed == null)
            {
                return NotFound(new { errorText = "Completed is not found" } );
            }

            return Ok(completed);
        }

        // Добавить выполненое задание
        [HttpPost]
        public async Task<IActionResult> PostResultAsync(int userId, int roomId, int questionId)
        {

            if (!_db.Users.Any(x => x.Id == userId))
            {
                return NotFound(new { errorText = "User not found" });
            }

            if (!_db.Rooms.Any(x => x.Id == roomId))
            {
                return NotFound(new { errorText = "Room not found" });
            }

            if (!_db.Questions.Any(x => x.Id == questionId))
            {
                return NotFound(new { errorText = "Question not found" });
            }

            Completed completed = await _db.Completeds.FirstOrDefaultAsync(x => x.UserId == userId && x.RoomId == roomId && x.QuestionId == questionId);

            if (completed != null)
            {
                return BadRequest("Completed is exit");
            }

            _db.Completeds.Add(new Completed() { UserId = userId, RoomId = roomId, QuestionId = questionId });
            await _db.SaveChangesAsync();

            return Ok("Copleted created");
        }
        
        // Добавить пользователя
        [HttpPost("/userAdd")]
        public async Task<IActionResult> PostUserAsync(string name, string surname, string email, string password)
        {
            try
            {
                if (_db.Users.Any(x => x.Name == name && x.SurName == surname && x.Email == email && x.Password == password))
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
    }
}
