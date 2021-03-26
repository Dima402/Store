using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace Users_last
{
    /// <summary>
    /// Interaction logic for Addition.xaml
    /// </summary>
    public partial class Addition : Window
    {
        string ConString = ConfigurationManager.ConnectionStrings["Users_last.Properties.Settings.ConnectionString"].ConnectionString;
        public Addition()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection myConnection = new SqlConnection(ConString);

            myConnection.Open();

            string sInsSql = "Insert into Users_last( LastName, Name, Patronymic, Email, Phone, Login, Password) Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";

            string Фамилия = lastname.Text;
            string Имя = name.Text;
            string Отчество = patronymic.Text;
            string Почта = email.Text;
            string Телефон = phone.Text;
            string Логин = login.Text;
            string Пароль = password.Text;

            string sInsSotr = string.Format(sInsSql, Фамилия, Имя, Отчество, Почта, Телефон, Логин, Пароль);
            SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

            cmdIns.ExecuteNonQuery();

            MessageBox.Show("Добавление закончено.", "Сообщение");

            myConnection.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
