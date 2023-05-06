using Napelem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Text.Json;


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

        private async void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            emp.name = nameTextBox.Text;
            emp.username = userNameTextBox.Text;
            emp.role = roleComboBox.Text;
            emp.password = passTextBox.Password;
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(emp), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"api/Admin", content);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Registration was successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }




        }
    }
}
