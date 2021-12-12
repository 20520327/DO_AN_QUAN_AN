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
using MaterialDesignThemes.Wpf;
using QLQA;

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
        #region Control Panel
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Thuvien.exit();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Sign up button
        private void btsignup_Click(object sender, RoutedEventArgs e)
        {
            signup lg = new signup();
            App.swapMainWindow(lg);
            this.Close();
        }
        #endregion

        #region Login
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {


            string User = tbUsername.Text.ToString();
            string Pass = tbPassword.Password.ToString();
            if (SQL.CheckLogin(User, Pass))
            {
                maintable a = new maintable();
                App.swapMainWindow(a);
            }
            else if (tbUsername.Text.ToString() == "" || tbPassword.Password.ToString() == "")
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Bạn chưa nhập thông tin.\nVui lòng nhập vào.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "login");
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Sai mật khẩu hoặc tài khoản!\nVui lòng nhập lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "login");
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string User = tbUsername.Text.ToString();
                string Pass = tbPassword.Password.ToString();
                if (SQL.CheckLogin(User, Pass))
                {
                    maintable a = new maintable();
                    a.Show();
                    this.Close();
                }
                else if (tbUsername.Text.ToString() == "" || tbPassword.Password.ToString() == "")
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Bạn chưa nhập thông tin.\nVui lòng nhập vào.");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "login");
                }
                else
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Sai mật khẩu hoặc tài khoản!\nVui lòng nhập lại.");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "login");
                }
            }
        }
        #endregion
    }

}
