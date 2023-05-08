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
    
    public partial class storageManager : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public storageManager()
        {
            InitializeComponent();
            Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        } 
        

        private void mainExitBtn_Click(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private void addItem(object sender, RoutedEventArgs e)
        {
        }

        private void changePrice_Quantity_Btn(object sender, RoutedEventArgs e)
        {
        }

        private void NewPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
