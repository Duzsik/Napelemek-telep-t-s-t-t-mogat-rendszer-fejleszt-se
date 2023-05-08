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
    /// Interaction logic for raktarVezeto.xaml
    /// </summary>
    /// 
    
    public partial class storageManager : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public async void Load()
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
                    ProductComboBox.Items.Add(components[i].componentID +" "+ components[i].name);
                }
            }
        }
        public storageManager()
        {
            InitializeComponent();
            Load();
            Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        } 
        

        private void mainExitBtn_Click(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private async void addItem(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            Component comp = new Component();
            comp.name = assetNameTextBox.Text;
            comp.price = int.Parse(assetPriceTextBox.Text);
            comp.max_quantity = int.Parse(assetMaxTextBox.Text);
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comp), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Component/AddComponent", content);
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("The product added to the database");
            }

        }

        private async void changePrice_Quantity_Btn(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            Component comp = new Component();
            string[] compData = ProductComboBox.Text.Split(' ');
            comp.componentID = int.Parse(compData[0]);
            comp.name = compData[1];
            if(NewPriceTextBox.Text == String.Empty)
            {
                comp.max_quantity = int.Parse(NewPriceTextBox_Copy.Text);
                var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comp), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"api/Component/ChangeMaxQuantity", content);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("The max quantity has been updated.");
                }
            }
            else if (NewPriceTextBox_Copy.Text == String.Empty)
            {
                comp.price = int.Parse(NewPriceTextBox.Text);
                var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comp), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"api/Component/ChangePrice", content);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("The price has been updated.");
                }
            }
            else if (NewPriceTextBox.Text != String.Empty && NewPriceTextBox_Copy.Text != String.Empty)
            {
                comp.max_quantity = int.Parse(NewPriceTextBox_Copy.Text);
                var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comp), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"api/Component/ChangeMaxQuantity", content);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("The max quantity has been updated.");
                }
                comp.price = int.Parse(NewPriceTextBox.Text);
                content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comp), System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync($"api/Component/ChangePrice", content);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("The price has been updated.");
                }


            }
        }

        private void NewPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
