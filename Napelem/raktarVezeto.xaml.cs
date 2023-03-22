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
    }
}
