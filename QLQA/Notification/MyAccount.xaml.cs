using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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


namespace QLQA.Notification
{
    /// <summary>
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : UserControl, INotifyPropertyChanged
    {
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public MyAccount()
        {
            InitializeComponent();
        }



        #region Peek password
        public event PropertyChangedEventHandler PropertyChanged;

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.CompareOrdinal(Unmask_pass.Text, this.tbPassword.Password) == 0)
                return;
            Unmask_pass.Text = this.tbPassword.Password;
        }
        private void Unmask_pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.CompareOrdinal(Unmask_pass.Text, this.tbPassword.Password) == 0)
                return;
            this.tbPassword.Password = Unmask_pass.Text;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            //Thông báo pass thay đổi để check cập nhật đúng cho cái textbox
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Unsee_Checked(object sender, RoutedEventArgs e)
        {
            this.tbPassword.Visibility = Visibility.Hidden;
            Unmask_pass.Visibility = Visibility.Visible;
        }

        private void Unsee_Unchecked(object sender, RoutedEventArgs e)
        {
            this.tbPassword.Visibility = Visibility.Visible;
            Unmask_pass.Visibility = Visibility.Hidden;
        }
        #endregion

        private void UpdateAC_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Aemployee_ID = SQL.lg.EMPLOYEEid;
            
            string Ausername = tbUsername.Text.ToString();
            string Apassword = tbPassword.Password.ToString();
            string Aconfirm_pass = tbConfirmPassword.Password.ToString();
            if (Apassword != Aconfirm_pass)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Mật khẩu không giống nhau !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "Myaccount");
                tbPassword.Focus();
            }

            //Viết SQL
            string updateAccount = "UPDATE ACCOUNT " +
                                    "SET USERNAME = N'" + Ausername + "', PASSWORD = N'" + Apassword + "' " +
                                    "WHERE EMPLOYEEid = '" + Aemployee_ID + "'";
            SqlCommand queryupdateAccount = new SqlCommand(updateAccount, ketnoi);

            try
            {
                queryupdateAccount.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Cập nhật tài khoản thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "Myaccount");

            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi cập nhật tài khoản!\nXin hãy kiểm tra lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "Myaccount");
            }
        }
        #region Load Myaccount
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsername.Text = SQL.lg.USERNAME.ToString();
            if (SQL.lg.ROLEid == 0)
            {
                tbPosition.Text = "Người quản lí";
            }
            else
            {
                tbPosition.Text = "Nhân viên";
            }
            tbPassword.Password = SQL.lg.PASSWORD.ToString();
            Unmask_pass.Text = SQL.lg.PASSWORD.ToString();
        }
        #endregion

        
    }
}
