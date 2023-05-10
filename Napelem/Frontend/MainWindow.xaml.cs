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
using Napelem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using Newtonsoft.Json;



namespace Napelem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
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
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            emp.username = userTextBox.Text;
            emp.password = passwordBox.Password;
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            try
            {
                var response = await client.GetAsync($"api/Employee?username={emp.username}&password={emp.password}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<Employee>(responseBody);
                if (employee == null)
                {
                    MessageBox.Show("Username or password is incorrect");
                }
                else
                {
                    if (employee.role == "admin")
                    {
                        admin adminWindow = new admin();
                        this.Close();
                        adminWindow.Show();

                    }
                    if (employee.role == "warehouse manager")
                    {
                        storageManager raktarVezetoWindow = new storageManager();
                        this.Close();
                        raktarVezetoWindow.Show();
                    }
                    if (employee.role == "professional")
                    {
                        professional prof = new professional(employee);
                        
                        this.Close();
                        prof.Show();
                    }
                    if (employee.role == "warehouse worker")
                    {
                        stockKeeper store = new stockKeeper();
                        this.Close();
                        store.Show();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
        private void Grid_ContextMenuClosing(object sender, RoutedEventArgs e)
        {

        }
    }
}
