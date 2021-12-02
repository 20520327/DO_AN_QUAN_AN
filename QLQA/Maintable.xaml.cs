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

        private void Minimize_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information) != MessageBoxResult.OK)
            {
            }
            else
            {
                Thuvien.exit();
            }
        }

        private void btAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SQL.lg.ROLEid == 0)
            {
                account nv = new account();
                this.Hide();
                nv.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
        //Nhân viên
        private void btEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(SQL.lg.ROLEid == 0)
            {
                employee nv = new employee();
                this.Hide();
                nv.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btReport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
        
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn đăng xuất ?","Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information) != MessageBoxResult.OK)
            {
            }
            else
            {
                login lg = new login();
                this.Close();
                lg.Show();
            }
        }

        private void Mainform_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
