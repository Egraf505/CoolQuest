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

        // Pages
        private QuestionsPage _questionsPage;
        private RoomAddUpdate _roomAddUpdate;
        public Page backPage { get; set; }

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
                _selectedRoom = value;
                CurrentPage = _questionsPage;
                using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                {
                    _questionsPage.Questions = new ObservableCollection<Question>(db.Questions.Where(x => x.RoomId == SelectedRoom.Id));
                }            
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

        public ICommand AddRoom
        {
            get
            {
                return new DelegateCommand(() => {
                    CurrentPage = new RoomAddUpdate();                   
                });
            }
        }

        public ICommand UpdateRoom
        {
            get
            {
                return new DelegateCommand<Room>((room) =>
                {
                    CurrentPage = _roomAddUpdate;
                    _roomAddUpdate.Room = room;
                    _roomAddUpdate.Room = SelectedRoom;
                }, (room) => room != null);
            }
        }

        public ICommand DeleteRoom
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (MessageBox.Show("Вы точно хотите удалить комнату ? \n Вместе с ней удалятся все вопросы","Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                        {
                            db.Rooms.Remove(SelectedRoom);
                        }
                        MessageBox.Show($"Комната {SelectedRoom.Id} удалена ");
                    }
                }, () => SelectedRoom != null);
            }
        }        

        public AdminPanelViewModel()
        {
            _questionsPage = new QuestionsPage();
            _roomAddUpdate = new RoomAddUpdate();
           
            using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
            {
                Rooms = new ObservableCollection<Room>(db.Rooms.ToList());               
            }

            CurrentPage = _questionsPage;
        }   
        

    }
}
