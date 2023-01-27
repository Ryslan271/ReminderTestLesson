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
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new Login().ShowDialog();
            Close();
        }

        private void RegistButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateDataTextBoxs() == false)
                return;

            User user = App.DBConnection.User.FirstOrDefault(x => x.Login == LoginTextBox.Text.Trim());

            if (user == null)
            {
                user = new User()
                {
                    Login = LoginTextBox.Text,
                    Password = LoginTextBox.Text,
                    Name = Name.Text
                };

                App.DBConnection.User.Add(user);

                App.DBConnection.SaveChanges();

                new MainWindow().ShowDialog();
                Close();
                return;
            }

            MessageBox.Show("Такой логин уже используется");
        }

        private bool ValidateDataTextBoxs() =>
            LoginTextBox.Text == "" &&
            PasswordTextBox.Text == "" &&
            Name.Text == "";
    }
}
