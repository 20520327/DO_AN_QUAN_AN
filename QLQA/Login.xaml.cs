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

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Thuvien.exit();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btsignup_Click(object sender, RoutedEventArgs e)
        {
            signup lg = new signup();
            this.Hide();
            lg.ShowDialog();
            this.Show();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            //maintable a = new maintable();
            //a.Show();
            //this.Close();

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
                MessageBox.Show("Bạn chưa nhập thông tin !\nXin vui lòng nhập vào !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tên tài khoản !\nVui lòng nhập lại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    
}
