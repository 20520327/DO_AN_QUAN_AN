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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Thuvien.exit();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            Thuvien.minimized();
        }

        private void nutLogin_Click(object sender, RoutedEventArgs e)
        {
            maintable a = new maintable();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
    
}
