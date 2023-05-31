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
using Azure;

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
            FilterProject.Items.Clear();
            var response = await client.GetAsync($"api/Project/ListProjects");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var projectsJson = obj["value"].ToString();
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
                ProjectDataGrid.ItemsSource = projects;
                for (int i = 0; i < projects.Count; i++)
                {
                    projectcmbbx.Items.Add(projects[i].projectID + " " + projects[i].name);
                    if (projects[i].status=="Scheduled")
                    {
                        FilterProject.Items.Add(projects[i].projectID + " " + projects[i].name);
                    }
                    
                }

            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            exit();
        }
        public class ReservationsAndProjectId
        {
            public List<Reservation> resers { get; set; }
            public int projectId { get; set; }
        }

        
        
        private async void ChangeProjectStatus(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            string[] projData = projectcmbbx.Text.Split(' ');
            var response = await client.GetAsync($"api/Project/GetProjectById?projectID={projData[0]}");//státusz check egyben
            if(response.IsSuccessStatusCode==true)
            {
                string json = await response.Content.ReadAsStringAsync();
                Project project = JsonConvert.DeserializeObject<Project>(json);
                if (project.projectID == int.Parse(projData[0]))
                {
                    response = await client.GetAsync($"api/Reservation/ListReservation");
                    if (response.IsSuccessStatusCode == true)
                    {
                        json = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<JObject>(json);
                        var reservationJson = obj["value"].ToString();
                        var reservations = JsonConvert.DeserializeObject<List<Reservation>>(reservationJson);

                        ReservationsAndProjectId reser = new ReservationsAndProjectId();
                        reser.resers = reservations;
                        reser.projectId = project.projectID;
                        json = JsonConvert.SerializeObject(reser);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        response = await client.PostAsync("api/Storage/ChangeStorage", content);
                        if (response.IsSuccessStatusCode == true)
                        {
                            if (project.status != "InProgress")
                            {
                                project.status = "InProgress";
                                MessageBox.Show("Status changed.");
                            }                            
                            Log log = new Log()
                            {
                                projectID = project.projectID,
                                status = project.status,
                                timestamp = DateTime.Now.ToString()
                            };
                            content = new StringContent(System.Text.Json.JsonSerializer.Serialize(project), System.Text.Encoding.UTF8, "application/json");
                            response = await client.PostAsync($"api/Project/ChangeStatus", content);

                            content = new StringContent(System.Text.Json.JsonSerializer.Serialize(log), System.Text.Encoding.UTF8, "application/json");
                            response = await client.PostAsync($"api/Log/AddLog", content);

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Project status is incorrect!", "WARNING!");
            }
        }






        private async void ProjectSelection(object sender, SelectionChangedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            if(FilterProject.Items.Count!=0)
            {
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

                    for (int i = 0; i < reservations.Count; i++)
                    {
                        if (reservations[i].projectID == project.projectID)
                        {
                            try
                            {
                                response = await client.GetAsync($"api/Storage/GetStorage?componentID={reservations[i].componentID.ToString()}");
                                response.EnsureSuccessStatusCode();
                                //itt valami hibádzik
                                responseBody = await response.Content.ReadAsStringAsync();
                                var stor = JsonConvert.DeserializeObject<Storage>(responseBody);
                                filteredComponent.Add(stor);
                            }catch (Exception ex)
                            {
                                MessageBox.Show("The selected project does not have a reservation.");
                            }
                            
                        }
                    }
                }
                WorkerDataGrid.ItemsSource = filteredComponent;
            }
                
            
            
            
            
        }
        private void refreshBtn(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
