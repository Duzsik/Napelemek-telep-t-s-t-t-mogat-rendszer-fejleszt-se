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
        public Project project { get; set; }
        public Component component { get; set; }
    }
    
    public partial class professional : Window
    {
        private Employee emp;

        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public professional(Employee e)
        {
            InitializeComponent();
            LoadCompontents();
            LoadProjects();
            this.emp = e;
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

        private async void addAssetsToProjectBtn(object sender, RoutedEventArgs e)
        {

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");

            Project pro = new Project();
            string[] proData = ProjectIdComboBox.Text.Split(' ');
            pro.projectID = int.Parse(proData[0]);

            Component comp = new Component();
            string[] compData = assetSelectComboBox.Text.Split(' ');
            comp.componentID = int.Parse(compData[0]);

            ProjectComponent projectComp = new ProjectComponent();
            projectComp.component = comp;
            projectComp.project = pro;

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(projectComp), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Reservation/AddReservation", content);
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Intake was successful.");
            }
        }

        private async void AddNewProjectBtn(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");          
            Project addPro = new Project();
            addPro.name = projectNameTextBox.Text;
            addPro.project_price = int.Parse(workPriceTextBox.Text);
            addPro.estimated_Time = int.Parse(workTimeTextBox.Text);
            addPro.project_description = descriptionTextBox.Text;
            addPro.project_location = projectLocationTextBox.Text;
            addPro.project_orderer = CostumerNameTextBox.Text;
            addPro.wage = 2000;
            addPro.status = "New";
            addPro.employeeID = emp.employeeID;
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(addPro), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Project/AddProject", content);
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Intake was successful.");
            }
        }
    }
}
