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
    internal class RoomRepository : IRepository<Room>
    {
        private CoolQuestContex _db;
        public RoomRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoolQuestContex>();
            var options = optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString).Options;

            this._db = new CoolQuestContex(options);
        }
        public void Create(Room item)
        {
            _db.Rooms.Add(item);
        }

        public void Delete(Room item)
        {
            Room room = _db.Rooms.Find(item.Id);
            if (room != null)
            {
                _db.Rooms.Remove(item);
            }            
        }        

        public Room GetItem(int id)
        {
            return _db.Rooms.Find(id);
        }

        public IEnumerable<Room> GetItems()
        {
            return _db.Rooms.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Room item)
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
