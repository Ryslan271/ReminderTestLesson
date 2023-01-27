using Reminder.CocnectDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Reminder.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ReminderTab> Reminders
        {
            get { return (ObservableCollection<ReminderTab>)GetValue(RemindersProperty); }
            set { SetValue(RemindersProperty, value); }
        }

        public static readonly DependencyProperty RemindersProperty =
            DependencyProperty.Register("Reminders", typeof(ObservableCollection<ReminderTab>), typeof(MainWindow));


        public MainWindow()
        {
            Reminders = new ObservableCollection<ReminderTab>(App.DBConnection.ReminderTab);

            InitializeComponent();
        }
    }
}
