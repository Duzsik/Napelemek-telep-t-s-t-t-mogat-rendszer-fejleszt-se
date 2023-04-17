﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using Napelem.Connection;

namespace Napelem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connection.TCPConnection TCP;
    
        public MainWindow()
        {
            InitializeComponent();
            TCP = new Connection.TCPConnection();
            Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TCP.TCPCloseConnection();
        }

        private void ShowPass_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void ShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
        }

        //Login button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void raktarBtn_Click(object sender, RoutedEventArgs e)
        {
            raktarVezeto raktarVezetoWindow = new raktarVezeto();
            this.Close();
            raktarVezetoWindow.Show();
        }
        private void Grid_ContextMenuClosing(object sender, RoutedEventArgs e)
        {

        }
    }
}
