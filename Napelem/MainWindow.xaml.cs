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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace Napelem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database.Database data = new Database.Database();
        public MainWindow()
        {
            InitializeComponent();
            Database.Database data = new Database.Database();
            data.CreateTables(data.GetPostgreSQLConnection());
        }

        private void ShowPass_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void ShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
        }

        //Login button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(userTextBox.Text.ToString()) || string.IsNullOrEmpty(passwordBox.Password.ToString()))
            {
                MessageBox.Show("Fill the textboxs!");
            }
            else
            {
                Database.Employee employee = new Database.Employee();
                employee = data.GetEmployeeByUsernameAndPassword(userTextBox.Text.ToString(), passwordBox.Password.ToString());
                if (employee == null)
                {
                    MessageBox.Show("This user doesn't exists.");
                }
                else if (employee.role == "admin")
                {
                    admin adminWindow = new admin();
                    this.Close();
                    adminWindow.Show();
                }
                else if (employee.role != "professional")
                {
                    professional professionalWindow = new professional();
                    this.Close();
                    professionalWindow.Show();
                }
                else if (employee.role != "warehouse worker")
                {
                    raktaros wareHouseWorker = new raktaros();
                    this.Close();
                    wareHouseWorker.Show();
                }
                else if (employee.role != "warehouse manager")
                {
                    raktarVezeto wareHouseManager = new raktarVezeto();
                    this.Close();
                    wareHouseManager.Show();

                }

            }

            


        }

        private void raktarBtn_Click(object sender, RoutedEventArgs e)
        {
            raktarVezeto raktarVezetoWindow = new raktarVezeto();
            this.Close();
            raktarVezetoWindow.Show();
        }
    }
}
