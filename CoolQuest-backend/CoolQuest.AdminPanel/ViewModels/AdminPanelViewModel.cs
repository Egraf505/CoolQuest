using CoolQuest.AdminPanel.Implementations;
using CoolQuest.DbContext.Models;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoolQuest.AdminPanel.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        public ObservableCollection<Room> RoomsAndQuestions;

        public AdminPanelViewModel()
        {
            Task.Factory.StartNew(SetCollection).Wait();
        }

        private async Task SetCollection()
        {
            RoomRepository roomRepository = new RoomRepository();

            List<Room> rooms = roomRepository.GetItems().ToList();

            roomRepository.Dispose();

            QuestionRepository questionRepository = new QuestionRepository();            

            foreach (var room in rooms)
            {
                room.Questions = questionRepository.GetQuestionsFromRoom(room.Id).ToList();
            }

            questionRepository.Dispose();

            RoomsAndQuestions = new ObservableCollection<Room>(rooms);

            MessageBox.Show("Я всё");
        }
    }
}
