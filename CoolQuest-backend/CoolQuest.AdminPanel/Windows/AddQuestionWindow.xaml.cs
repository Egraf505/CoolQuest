using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CoolQuest.AdminPanel.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestionWindow : Window, INotifyPropertyChanged
    {
        private Question _question = new Question();        

        public Question Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged("Question");
            }

        }

        public int RoomId { get; set; }

        private IEnumerable<CoolQuest.DbContext.Models.Type> _types;
        public IEnumerable<CoolQuest.DbContext.Models.Type> Types
        {
            get
            {
                return _types;
            }

            set
            {
                _types = value;
                OnPropertyChanged("Types");
            }
        }
        
        public AddQuestionWindow()
        {
            using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
            {
                Types = db.Types.ToList();
            }

            this.DataContext = this;
            InitializeComponent();
        }

        public void SetQuestion(Question question)
        {
            Question = question;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (Question.Id == 0)
                {
                    using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                    {
                        Question.RoomId = RoomId;
                        db.Questions.Add(Question);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Вопрос добавлен");
                }
                else
                {
                    using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                    {
                        db.Entry(Question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Вопрос изменён");
                }

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = false;
            }            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
