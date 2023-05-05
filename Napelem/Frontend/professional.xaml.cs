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
    /// Interaction logic for professional.xaml
    /// </summary>
    public partial class professional : Window
    {
        void exit()
        {
            MainWindow objmainWindow = new MainWindow();
            this.Close();
            objmainWindow.Show();
        }
        public Connection.TCPConnection TCP;
        public professional()
        {
            InitializeComponent();
            TCP = new Connection.TCPConnection();
            Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TCP.TCPCloseConnection();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            TCP.TCPSendMessage("Change project status");
        }

        private void addAssetsToProjectBtn(object sender, RoutedEventArgs e)
        {
            TCP.TCPSendMessage("Add assets to prject");
        }
    }
}
