using Reminder.CocnectDB;
using System.Data.Entity;
using System.Windows;

namespace Reminder
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ReminderDBEntities DBConnection = new ReminderDBEntities();

        public App()
        {
            DBConnection.User.Load();
            DBConnection.ReminderTab.Load();
        }
    }
}
