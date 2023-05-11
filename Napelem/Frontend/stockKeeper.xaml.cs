using Napelem.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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

namespace Napelem
{
    /// <summary>
    /// Interaction logic for raktaros.xaml
    /// </summary>
    public partial class stockKeeper : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
            
        }
        public stockKeeper()
        {
            InitializeComponent();
            Load();

        }

        async void Load()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            projectcmbbx.Items.Clear();
            var response = await client.GetAsync($"api/Project/ListProjects");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var projectsJson = obj["value"].ToString();
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
                ProjectDataGrid.ItemsSource = projects;
                for(int i = 0; i<projects.Count;i++)
                {
                    projectcmbbx.Items.Add(projects[i].projectID+" " + projects[i].name);
                    FilterProject.Items.Add(projects[i].projectID+" " + projects[i].name);
                }
                
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            exit();
        }


        private async void ChangeProjectStatus(object sender, RoutedEventArgs e)
        {
            Project proj = new Project();
            string[] projData = projectcmbbx.Text.Split(' ');
            proj.projectID = int.Parse(projData[0]);
            proj.name = projData[1];
            proj.status = "InProgress";
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(proj), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Project/ChangeStatus", content);
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Status changed.");
            }
        }



    

        private async void ProjectSelection(object sender, SelectionChangedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            string[] selectedProject = FilterProject.SelectedItem.ToString().Split(' ');
            int id = int.Parse(selectedProject[0]);
            var response = await client.GetAsync($"api/Project?projectID={id.ToString()}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(responseBody);
            List<Storage> filteredComponent = new List<Storage>();
            response = await client.GetAsync($"api/Reservation/ListReservation");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var reservationJson = obj["value"].ToString();
                var reservations = JsonConvert.DeserializeObject<List<Reservation>>(reservationJson);

                for(int i =0; i<reservations.Count; i++)
                {
                    if (reservations[i].projectID == project.projectID)
                    {
                        response = await client.GetAsync($"api/Storage/GetStorage?componentID={reservations[i].componentID.ToString()}");
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                        var stor = JsonConvert.DeserializeObject<Storage>(responseBody);
                        filteredComponent.Add(stor);
                    }
                }
            }
            
            WorkerDataGrid.ItemsSource = filteredComponent;
        }
    }
}
