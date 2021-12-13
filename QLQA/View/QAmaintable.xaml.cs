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
using UI;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QAmaintable.xaml
    /// </summary>
    public partial class QAmaintable : UserControl
    {
        public WindowState WindowState { get; private set; }

        public QAmaintable()
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
            DialogHost.Show(b, "main");
        }

        #region Đăng xuất
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Bạn có muốn đăng xuất ?");
            QLQA.Notification.LogOut b = new QLQA.Notification.LogOut();
            b.DataContext = dia;
            DialogHost.Show(b, "main");
        }

        #endregion
        #endregion

        private void Close()
        {
            throw new NotImplementedException();
        }


        private void Account_popup_Click(object sender, RoutedEventArgs e)
        {
            QLQA.Notification.MyAccount b = new QLQA.Notification.MyAccount();
            DialogHost.Show(b, "main");
        }
    }
}

