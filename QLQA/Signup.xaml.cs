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
    public partial class signup : Window
    {
        public signup()
        {
            InitializeComponent();
        }

        private void btexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btSignup_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
