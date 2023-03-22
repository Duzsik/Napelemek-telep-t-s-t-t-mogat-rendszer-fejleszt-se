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
    /// Interaction logic for raktarVezeto.xaml
    /// </summary>
    /// 
    
    public partial class raktarVezeto : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public raktarVezeto()
        {
            InitializeComponent();
            Database.Database data = new Database.Database();
            List<Database.Component> components = data.LoadComponents();
            if(components != null)
            {
                ProductComboBox.Items.Clear();
                foreach(Database.Component component in components )
                {
                    string componentData = component.componentID.ToString() + " " + component.name;
                    ProductComboBox.Items.Add(componentData);
                }
                ProductComboBox.SelectedIndex = 0;
            }
        }

        private void mainExitBtn_Click(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(assetNameTextBox.Text.ToString()) || string.IsNullOrEmpty(assetPriceTextBox.Text.ToString()) || string.IsNullOrEmpty(assetMaxTextBox.Text.ToString()))
            {
                MessageBox.Show("Fill all the textboxes .");
            }
            else
            {
                Database.Component comp = new Database.Component();
                comp.name = assetNameTextBox.Text.ToString();
                comp.price = int.Parse(assetPriceTextBox.Text);
                comp.maxQuantity = int.Parse(assetMaxTextBox.Text);
                Database.Database data = new Database.Database();
                data.InsertNewAssets(comp);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(NewPriceTextBox.Text.ToString()))
            {
                MessageBox.Show("Fill all the textboxes.");
            }
            else
            {
                Database.Database data = new Database.Database();
                data.UpdatePriceOfComponent(ProductComboBox.Text.ToString(), int.Parse(NewPriceTextBox.Text.ToString()));
            }
            
        }

        private void NewPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
