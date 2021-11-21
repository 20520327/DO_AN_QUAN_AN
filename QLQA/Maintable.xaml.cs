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
    public partial class maintable : Window
    {
        public maintable()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Minimize_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btAccount_Click(object sender, RoutedEventArgs e)
        {
            account tk = new account();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void btHistory_Click(object sender, RoutedEventArgs e)
        {
            revenue ls = new revenue();
            this.Hide();
            ls.ShowDialog();
            this.Show();
        }

        private void btList_Click(object sender, RoutedEventArgs e)
        {
            category dm = new category();
            this.Hide();
            dm.ShowDialog();
            this.Show();
        }

        private void btEmployee_Click(object sender, RoutedEventArgs e)
        {
            employee nv = new employee();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void btReport_Click(object sender, RoutedEventArgs e)
        {
            report bc = new report();
            this.Hide();
            bc.ShowDialog();
            this.Show();
        }

        private void btFood_Click(object sender, RoutedEventArgs e)
        {
            food fd = new food();
            this.Hide();
            fd.ShowDialog();
            this.Show();
        }

        private void btTable_Click(object sender, RoutedEventArgs e)
        {
            table tb = new table();
            this.Hide();
            tb.ShowDialog();
            this.Show();
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            order db = new order();
            this.Hide();
            db.ShowDialog();
            this.Show();
        }
    }
}
