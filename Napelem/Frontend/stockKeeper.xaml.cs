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
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            var response = await client.GetAsync($"api/Project/ListProjects");
            if (response.IsSuccessStatusCode == true)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var projectsJson = obj["value"].ToString();
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
                string[] projData = projectcmbbx.Text.Split(' ');
                for (int n = 0; n < projects.Count; n++)
                {
                    if (projects[n].projectID == int.Parse(projData[0]))//projekt id keresése
                    {
                        if (projects[n].status == "Scheduled")//státusz ellenőrzés
                        {
                            response = await client.GetAsync($"api/Reservation/ListReservation");
                            if (response.IsSuccessStatusCode == true)
                            {
                                json = await response.Content.ReadAsStringAsync();
                                obj = JsonConvert.DeserializeObject<JObject>(json);
                                var reservationJson = obj["value"].ToString();
                                var reservations = JsonConvert.DeserializeObject<List<Reservation>>(reservationJson);
                                for (int i = 0; i < reservations.Count; i++)
                                {
                                    if (reservations[i].projectID == projects[n].projectID)//foglalás projectID ellenzőrzés
                                    {
                                        response = await client.GetAsync($"api/Component/SendComponent");
                                        if (response.IsSuccessStatusCode == true)
                                        {
                                            json = await response.Content.ReadAsStringAsync();
                                            obj = JsonConvert.DeserializeObject<JObject>(json);
                                            var componentsJson = obj["value"].ToString();
                                            var components = JsonConvert.DeserializeObject<List<Component>>(componentsJson);
                                            for (int j = 0; j < components.Count; j++)
                                            {
                                                if (reservations[i].componentID == components[j].componentID)//a jó foglalásban keresi a lefoglalt compoentID-t
                                                {
                                                    components[j].quantity -= reservations[i].reservationQuantity;
                                                    var CompContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(components[j]), System.Text.Encoding.UTF8, "application/json");
                                                    response = await client.PostAsync($"api/Component/ChangeQuantity", CompContent);
                                                }
                                                response = await client.GetAsync($"api/Storage/ListStorages");
                                                if (response.IsSuccessStatusCode == true)
                                                {
                                                    json = await response.Content.ReadAsStringAsync();
                                                    obj = JsonConvert.DeserializeObject<JObject>(json);
                                                    var storageJson = obj["value"].ToString();
                                                    var storages = JsonConvert.DeserializeObject<List<Storage>>(storageJson);
                                                    while (reservations[i].reservationQuantity != 0)
                                                    {
                                                        for (int k = 0; k < storages.Count; k++)
                                                        {
                                                            if (components[j].componentID == storages[k].componentID)//storage-ben componentID egyezik-e
                                                            {

                                                                if (storages[k].current_quantity - reservations[i].reservationQuantity < 0)
                                                                {
                                                                    reservations[i].reservationQuantity -= storages[k].current_quantity;
                                                                    storages[k].current_quantity -= storages[k].current_quantity;
                                                                    var StorConent = new StringContent(System.Text.Json.JsonSerializer.Serialize(storages[k]), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Storage/ChangeCurrent_quantity", StorConent);
                                                                    var ResConent = new StringContent(System.Text.Json.JsonSerializer.Serialize(reservations[i]), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Reservation/ChangeReservation_quantity", ResConent);
                                                                }
                                                                else
                                                                {
                                                                    storages[k].current_quantity -= reservations[i].reservationQuantity;
                                                                    reservations[i].reservationQuantity -= reservations[i].reservationQuantity;
                                                                    var StorConent = new StringContent(System.Text.Json.JsonSerializer.Serialize(storages[k]), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Storage/ChangeCurrent_quantity", StorConent);
                                                                    var ResConent = new StringContent(System.Text.Json.JsonSerializer.Serialize(reservations[i]), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Reservation/ChangeReservation_quantity", ResConent);
                                                                    if (projects[n].status != "InProgress")
                                                                    {
                                                                        MessageBox.Show("Status changed.");
                                                                    }
                                                                    projects[n].status = "InProgress";
                                                                    Log log = new Log()
                                                                    {
                                                                        projectID = projects[n].projectID,
                                                                        status = projects[n].status,
                                                                        timestamp = DateTime.Now.ToString()
                                                                    };
                                                                    var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(projects[n]), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Project/ChangeStatus", content);
                                                                    
                                                                    content = new StringContent(System.Text.Json.JsonSerializer.Serialize(log), System.Text.Encoding.UTF8, "application/json");
                                                                    response = await client.PostAsync($"api/Log/AddLog", content);
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Status is invalid!", "Conflict");
                        }
                    }
                }
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
                        //itt valami hibádzik
                        responseBody = await response.Content.ReadAsStringAsync();
                        var stor = JsonConvert.DeserializeObject<Storage>(responseBody);
                        filteredComponent.Add(stor);
                    }
                }
            }
            
            WorkerDataGrid.ItemsSource = filteredComponent;
        }
        private void refreshBtn(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
