using Reminder.CocnectDB;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Reminder.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
                return;

            User user = App.DBConnection.User.FirstOrDefault(x => x.Login == LoginTextBox.Text.Trim() && x.Password == PasswordTextBox.Text.Trim());

            if (user == null)
            {
                MessageBox.Show("Такого пользователя нет в системе");
                return;
            }

            new MainWindow().ShowDialog();
            Hide();
        }

        private bool ValidateData() =>
            LoginTextBox.Text == "" &&
            PasswordTextBox.Text == "";

        private void RegistButton_Click(object sender, RoutedEventArgs e)
        {
            new Regist().ShowDialog();
            Close();
        }
    }
}
