using CoolQuest.DbContext.Context;
using CoolQuest.DbContext.Models;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoolQuest.AdminPanel.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoomAddUpdate.xaml
    /// </summary>
    public partial class RoomAddUpdate : Page, INotifyPropertyChanged
    {
        private CoolQuestContex _db;

        private Room _room;
        public Room Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                OnPropertyChanged("Room");
            }
        }
        public RoomAddUpdate()
        {
            this.DataContext = this;
            Room = new Room() { Id = 0 };
            InitializeComponent();
        }

        public ICommand AddRoom
        {
            get
            {
                return new DelegateCommand(() => 
                {
                    if (Room.Id == 0)
                    {
                        using (_db = new CoolQuestContex(DbOptions.Options))
                        {
                            _db.Add(Room);
                            _db.SaveChanges();
                        }
                        MessageBox.Show("Дьбавление успешно");
                    }
                    else
                    {
                        using (_db = new CoolQuestContex(DbOptions.Options))
                        {
                            _db.Entry(Room).State = EntityState.Modified;
                            _db.SaveChanges();
                        }
                        MessageBox.Show("Изменение успешно");
                    }
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
