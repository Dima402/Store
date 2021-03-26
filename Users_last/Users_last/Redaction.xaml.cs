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
    /// Interaction logic for Redaction.xaml
    /// </summary>
    public partial class Redaction : Window
    {
        string ConString = ConfigurationManager.ConnectionStrings["Users_last.Properties.Settings.ConnectionString"].ConnectionString;

        public Redaction()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "Select * FROM Users_last WHERE Id =" + GiveID.redact;
            SqlConnection myConnection = new SqlConnection(ConString);
            SqlCommand sda = new SqlCommand(query, myConnection);
            myConnection.Open();
            SqlDataReader rd = sda.ExecuteReader();
            while (rd.Read())
            {
                id.Text = rd[0].ToString();
                lastname.Text = rd.GetString(1);
                name.Text = rd.GetString(2);
                patronymic.Text = rd.GetString(3);
                email.Text = rd.GetString(4);
                phone.Text = rd.GetString(5);
                login.Text = rd.GetString(6);
                password.Text = rd.GetString(7);
            }
            myConnection.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(ConString);

            myConnection.Open();

            string Фамилия = lastname.Text;
            string Имя = name.Text;
            string Отчество = patronymic.Text;
            string Почта = email.Text;
            string Телефон = phone.Text;
            string Логин = login.Text;
            string Пароль = password.Text;

            string sInsSql = "Update Users_last Set LastName = '" + Фамилия + "', Name = '" + Имя + "', Patronymic = '" + Отчество + "', Email = '" + Почта + "', Phone = '" + Телефон + "', Login = '" + Логин + "', Password = '" + Пароль + "' Where Id = " + GiveID.redact;

            string sInsSotr = string.Format(sInsSql);
            SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);
            cmdIns.ExecuteNonQuery();

            myConnection.Close();

            MessageBox.Show("Обновление завершено.", "Сообщение");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
