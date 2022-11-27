using CoolQuest.backend.DTO;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using CoolQuest.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
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


        // получить вопрос по id
        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetAsync(int questionId)
        {
            Question question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == questionId);

            if (question == null)
                return NotFound(new { errorText = "Question not found" });

            IEnumerable<AnswerFalseDTO> answerFalses = _db.AnswerFalses.Where(x => x.QuestionId == question.Id).Select(x => new AnswerFalseDTO() { Id = x.Id, Title = x.Title });
            var type = await _db.Types.FirstOrDefaultAsync(x => x.Id == question.TypeId);
            var room = await _db.Rooms.FirstOrDefaultAsync(x => x.Id == question.RoomId);

            QuestionDTO questionDTO = new() { TitleQuestion = question.Title, Type = type.Title, Answer = question.Answer, AnswerFalses = answerFalses };


            return Ok(questionDTO);
        }

        // вернуть все вопросы с комнаты
        [HttpGet("/room/{roomId}")]
        public async Task<IActionResult> GetQuestionsAsync(int roomId)
        {
            if (!await _db.Rooms.AnyAsync(x => x.Id == roomId))
            {
                return NotFound(new { errorText = "Room not found" } );
            }

            var questions = await _db.Questions.Where(x => x.RoomId == roomId).ToListAsync();

            ICollection<QuestionDTO> questionDTOs = new List<QuestionDTO>();

            foreach (var question in questions)
            {
                QuestionDTO questionDTO = new QuestionDTO();
                questionDTO.TitleQuestion = question.Title;
                questionDTO.Type = _db.Types.FirstOrDefaultAsync(x => x.Id == question.TypeId).Result!.Title;
                questionDTO.Answer = question.Answer;
                questionDTO.AnswerFalses = _db.AnswerFalses.Where(x => x.QuestionId == question.Id).Select(x => new AnswerFalseDTO() { Id = x.Id, Title = x.Title});

                questionDTOs.Add(questionDTO);
            }
     
            return Ok(questionDTOs);
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
    }
}
