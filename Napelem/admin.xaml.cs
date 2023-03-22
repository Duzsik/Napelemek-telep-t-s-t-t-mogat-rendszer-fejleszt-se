using Napelem.Database;
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

namespace Napelem
{
    /// <summary>
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

               if (string.IsNullOrEmpty(nameTextBox.Text.ToString()) || string.IsNullOrEmpty(roleComboBox.Text.ToString()) || string.IsNullOrEmpty(userNameTextBox.Text.ToString()) || string.IsNullOrEmpty(passTextBox.Password.ToString()))
                {
                    MessageBox.Show("Fill all the textboxes.");
                }
                else
                {
                    Employee employee = new Employee();
                    employee.name = nameTextBox.Text.ToString();
                    employee.role = roleComboBox.Text.ToString();
                    employee.username = userNameTextBox.Text.ToString();
                    employee.password = passTextBox.Password.ToString();
                    Database.Database data = new Database.Database();
                    data.InsertEmployeesToDatabase(employee);
                }  
        }
    }
}
