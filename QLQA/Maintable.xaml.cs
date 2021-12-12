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
using MaterialDesignThemes.Wpf;

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
            QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Bạn có muốn đóng ứng dụng?");
            QLQA.Notification.Exit b = new QLQA.Notification.Exit();
            b.DataContext = dia;
            DialogHost.Show(b, "Maintable");
        }

        #region Đăng xuất
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Bạn có muốn đăng xuất ?");
            QLQA.Notification.LogOut b = new QLQA.Notification.LogOut();
            b.DataContext = dia;
            DialogHost.Show(b, "Maintable");
        }
        #endregion
        #endregion
        
        #region Các button

        #region Tài khoản
        private void btAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SQL.lg.ROLEid == 0)
            {
                account nv = new account();
                App.swapMainWindow(nv);
                this.Close();
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Bạn không có quyền truy cập !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "Maintable");
            }
        }
        #endregion

        #region Lịch sử đơn hàng
        private void btHistory_Click(object sender, RoutedEventArgs e)
        {
            revenue ls = new revenue();
            App.swapMainWindow(ls);
            this.Close();
        }
        #endregion

        #region Danh mục
        private void btList_Click(object sender, RoutedEventArgs e)
        {
            category dm = new category();
            App.swapMainWindow(dm);
            this.Close();
        }
        #endregion

        #region Nhân viên
        private void btEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(SQL.lg.ROLEid == 0)
            {
                employee nv = new employee();
                App.swapMainWindow(nv);
                this.Close();
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Bạn không có quyền truy cập !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "Maintable");
            }
        }
        #endregion

        #region Món ăn
        private void btFood_Click(object sender, RoutedEventArgs e)
        {
            food fd = new food();
            App.swapMainWindow(fd);
            this.Close();
        }
        #endregion

        #region Bàn ăn
        private void btTable_Click(object sender, RoutedEventArgs e)
        {
            table tb = new table();
            App.swapMainWindow(tb);
            this.Close();
        }
        #endregion

        #region Order
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            UI.order db = new UI.order();
            App.swapMainWindow(db);
            this.Close();
        }
        #endregion

        
        #endregion
    }
}
