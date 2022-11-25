using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolQuest.AdminPanel.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
        
    }
}
