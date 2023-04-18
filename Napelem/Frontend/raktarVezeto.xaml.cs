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
        public Connection.TCPConnection TCP;
        public raktarVezeto()
        {
            InitializeComponent();
            TCP = new Connection.TCPConnection();
            Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TCP.TCPCloseConnection();
        }

        private void mainExitBtn_Click(object sender, RoutedEventArgs e)
        {
            exit();
        }

        private void addItem(object sender, RoutedEventArgs e)
        {
            TCP.TCPSendMessage("Add item");
        }

        private void changePriceBtn(object sender, RoutedEventArgs e)
        {
            TCP.TCPSendMessage("Change price");            
        }

    }
}
