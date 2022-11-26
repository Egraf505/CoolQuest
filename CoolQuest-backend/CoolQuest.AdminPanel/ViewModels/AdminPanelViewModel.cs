using CoolQuest.AdminPanel.Pages;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoolQuest.AdminPanel.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        // bd
        private CoolQuestContex _db;
        private readonly DbContextOptions<CoolQuestContex> options;

        // Pages
        private QuestionsPage _questionsPage;

        // Collections
        private ObservableCollection<Room> _rooms;
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
                RaisePropertiesChanged("Rooms");
            }
        }

        // Current items
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                CurrentPage = _questionsPage;

                _selectedRoom = value;
                RaisePropertiesChanged("SelectedRoom");
            }
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                RaisePropertiesChanged("CurrentPage");
            }
        }

        
        public ObservableCollection<Question> Questions;

        public ICommand AddRoom
        {
            get
            {
                return new DelegateCommand(() => {
                   MessageBox.Show("Добавить комнату");
                });
            }
        }

        public AdminPanelViewModel()
        {
            _questionsPage = new QuestionsPage();
           
            using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
            {
                Rooms = new ObservableCollection<Room>(db.Rooms.ToList());
            }

            CurrentPage = _questionsPage;
        }   
        

    }
}
