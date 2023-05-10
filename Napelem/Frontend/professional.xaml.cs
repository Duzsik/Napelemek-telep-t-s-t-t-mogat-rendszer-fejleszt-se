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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Napelem.Models;
using System.Net.Http;

namespace Napelem
{
    /// <summary>
    /// Interaction logic for professional.xaml
    /// </summary>

    public class ProjectComponent
    {
        public Project Project { get; set; }
        public Component Component { get; set; }
    }
    public partial class professional : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public professional()
        {
            InitializeComponent();
        }
        public async void LoadCompontents()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");

            var response = await client.GetAsync($"api/Component/SendComponent");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var componentsJson = obj["value"].ToString();
                var components = JsonConvert.DeserializeObject<List<Component>>(componentsJson);
                for (int i = 0; i < components.Count; i++)
                {                   
                    assetSelectComboBox.Items.Add(components[i].componentID + " " + components[i].name);
                }
            }
        }
        public async void LoadProjects()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");

            var response = await client.GetAsync($"api/Project/ListProjects");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var projectsJson = obj["value"].ToString();
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
                for (int i = 0; i < projects.Count; i++)
                {
                    ProjectIdComboBox.Items.Add(projects[i].projectID + " " + projects[i].name);
                }
            }
        }

        private void newProject_exit1(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private void Project_exitBtn(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private void change_status_Btn(object sender, RoutedEventArgs e)
        {
            
        }

        private void addAssetsToProjectBtn(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
