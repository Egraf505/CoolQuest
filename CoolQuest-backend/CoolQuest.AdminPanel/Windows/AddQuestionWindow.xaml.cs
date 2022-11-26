using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        private ObservableCollection<CoolQuest.DbContext.Models.Type> _types;
        public ObservableCollection<CoolQuest.DbContext.Models.Type> Types
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

        private CoolQuest.DbContext.Models.Type _selectedType;
        private CoolQuest.DbContext.Models.Type SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public AddQuestionWindow()
        {
            using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
            {
                Types = new ObservableCollection<DbContext.Models.Type>(db.Types.ToList());
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
                        Question.Type =(CoolQuest.DbContext.Models.Type)combox.SelectedItem;
                        db.Questions.Add(Question);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Вопрос добавлен");
                }
                else
                {
                    using (CoolQuestContex db = new CoolQuestContex(DbOptions.Options))
                    {
                        Question.Type = (CoolQuest.DbContext.Models.Type)combox.SelectedItem;
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
