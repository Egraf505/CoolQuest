using CoolQuest.AdminPanel.Windows;
using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoolQuest.AdminPanel.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionsPage.xaml
    /// </summary>
    public partial class QuestionsPage : Page, INotifyPropertyChanged
    {
        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private ObservableCollection<Question> _questions;
        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                OnPropertyChanged("Questions");
            }
        }

        // Окна
        public AddQuestionWindow AddQuestionWindow = new AddQuestionWindow();

        public ICommand AddQuestion
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    AddQuestionWindow addQuestion = new AddQuestionWindow();
                    addQuestion.RoomId = (int)Questions.First().RoomId;
                    if (addQuestion.ShowDialog() == true)
                    {                        
                        using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                        {
                            int roomid = (int)Questions.First().RoomId;

                            Questions = new ObservableCollection<Question>(db.Questions.Where(x => x.RoomId == roomid));
                        }
                    }
                });
            }
        }

        public ICommand UpdateQuestion
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    AddQuestionWindow.RoomId = (int)Questions.First().RoomId;
                    AddQuestionWindow.SetQuestion(SelectedQuestion);
                    if (AddQuestionWindow.ShowDialog() == true)
                    {
                        MessageBox.Show("Вопрос добавлен");
                        using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                        {
                            int roomid = (int)Questions.First().RoomId;

                            Questions = new ObservableCollection<Question>(db.Questions.Where(x => x.RoomId == roomid));
                        }
                    }
                }, () => SelectedQuestion != null);
            }
        }

        public ICommand DeleteQuestion
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (MessageBox.Show("Вы точно хотите удалить вопрос ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        MessageBox.Show($"Вопрос удален");
                        using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                        {
                            var AnswerFalse = db.AnswerFalses.Where(x => x.QuestionId == SelectedQuestion.Id);
                            db.AnswerFalses.RemoveRange(AnswerFalse);
                            db.Questions.Remove(SelectedQuestion);
                            db.SaveChanges();
                        }

                        UpdateQuestions();
                    }
                }, () => SelectedQuestion != null);
            }
        }

        public void UpdateQuestions()
        {
            int roomId = (int)Questions.First().RoomId;

            using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
            {
                Questions = new ObservableCollection<Question>(db.Questions.Where(x => x.RoomId == roomId));
            }
        }

        public QuestionsPage()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
