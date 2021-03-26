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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string ConString = ConfigurationManager.ConnectionStrings["Users_last.Properties.Settings.ConnectionString"].ConnectionString;
        public Authorization()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select Login, Password from Users_last where Login ='" + Log.Text.Trim() + "' and Password ='" + Pass.Password.Trim() + "'";
            SqlConnection myConnection = new SqlConnection(ConString);
            SqlCommand sda = new SqlCommand(query, myConnection);
            myConnection.Open();
            SqlDataReader rd = sda.ExecuteReader();
            string Login = "null";
            string Password = "null";
            while (rd.Read())
            {
                Login = rd.GetString(0);
                Password = rd.GetString(1);
            }
            myConnection.Close();
            if (Log.Text == "admin123" && Pass.Password == "Admin123")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            else
            {
                if ((Login == "null") || (Password == "null"))
                {
                    MessageBox.Show(string.Format("Данные не введены или вы не зарегистрировались"), "Сообщение");
                }
                else
                {
                    MessageBox.Show(string.Format("Вы вошли в систему"), "Сообщение");
                }
            }
        }
    }
}
