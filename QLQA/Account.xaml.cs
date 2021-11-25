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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using QLQA;
using QLQA.Model;
using System.Data;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class account : Window
    {
        public account()
        {
            InitializeComponent();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btAddAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btDelAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btpdateAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btViewAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvAccount_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
