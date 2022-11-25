using CoolQuest.AdminPanel.Interfaces;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CoolQuest.AdminPanel.Implementations
{
    internal class QuestionRepository : IRepository<Question>
    {
        private CoolQuestContex _db;
        public QuestionRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoolQuestContex>();
            var options = optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString).Options;
            
            this._db = new CoolQuestContex(options);
        }
        public void Create(Question item)
        {
            _db.Questions.Add(item);
        }

        public void Delete(Question item)
        {
            Question question = _db.Questions.Find(item.Id);
            if (question != null)
            {
                _db.Questions.Remove(item);
            }
        }      

        public Question GetItem(int id)
        {
            return _db.Questions.Find(id);
        }      

        public IEnumerable<Question> GetItems()
        {
            return _db.Questions.ToList();
        }

        public IEnumerable<Question> GetQuestionsFromRoom(int roomID)
        {
            return _db.Questions.Where(x => x.RoomId == roomID).ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Question item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
