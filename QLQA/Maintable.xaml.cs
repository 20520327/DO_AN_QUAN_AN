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
        #region Control Panel
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
        #endregion

        #region Các button

        #region Tài khoản
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
        #endregion

        #region Lịch sử đơn hàng
        private void btHistory_Click(object sender, RoutedEventArgs e)
        {
            revenue ls = new revenue();
            this.Hide();
            ls.ShowDialog();
            this.Show();
        }
        #endregion

        #region Danh mục
        private void btList_Click(object sender, RoutedEventArgs e)
        {
            category dm = new category();
            this.Hide();
            dm.ShowDialog();
            this.Show();
        }
        #endregion

        #region Nhân viên
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
        #endregion

        #region Món ăn
        private void btFood_Click(object sender, RoutedEventArgs e)
        {
            food fd = new food();
            this.Hide();
            fd.ShowDialog();
            this.Show();
        }
        #endregion

        #region Bàn ăn
        private void btTable_Click(object sender, RoutedEventArgs e)
        {
            table tb = new table();
            this.Hide();
            tb.ShowDialog();
            this.Show();
        }
        #endregion

        #region Order
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            order db = new order();
            this.Hide();
            db.ShowDialog();
            this.Show();
        }
        #endregion

        #region Đăng xuất
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
        #endregion
        #endregion
    }
}
