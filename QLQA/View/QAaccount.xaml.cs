using MaterialDesignThemes.Wpf;
using QLQA.Model;
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
using UI;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QAaccount.xaml
    /// </summary>
    public partial class QAaccount : UserControl
    {
        public QAaccount()
        {
            InitializeComponent();
        }
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        #endregion

        #region Control Panel and Home button
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Account

        #region Thêm tài khoản

        private void btAddAccount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Aemployee_ID = int.Parse(tbIDEmployee.Text.ToString());
            int Arole_ID;
            string temp = cbRole.Text.ToString();
            if (temp == "Người quản lí")
            {
                Arole_ID = 0;
            }
            else
            {
                Arole_ID = 1;
            }

            string Ausername = tbUsername.Text.ToString();
            string Apassword = tbPassword.Password.ToString();
            string Aconfirm_pass = tbPassConfirm.Password.ToString();
            while (Apassword != Aconfirm_pass)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Mật khẩu không giống nhau !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                tbPassword.Focus();
                return;
            }

            //Viết SQL
            string saveAccount = "INSERT INTO ACCOUNT(EMPLOYEEid,ROLEid,USERNAME,PASSWORD) values (N'" + Aemployee_ID + "', N'" + Arole_ID + "', N'" + Ausername + "', N'" + Apassword + "');";
            SqlCommand querysaveAccount = new SqlCommand(saveAccount, ketnoi);

            try
            {
                querysaveAccount.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Thêm tài khoản thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi thêm tài khoản !\nVui lòng kiểm tra lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListAccountviewInfo();
        }
        #endregion

        #region Xoá tài khoản
        private void btDelAccount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Aemployee_ID = int.Parse(tbIDEmployee.Text.ToString());
            int Arole_ID;
            string temp = cbRole.Text.ToString();
            if (temp == "Người quản lí")
            {
                Arole_ID = 0;
            }
            else
            {
                Arole_ID = 1;
            }

            string Ausername = tbUsername.Text.ToString();
            string Apassword = tbPassword.ToString();
            string Aconfirm_pass = tbPassConfirm.ToString();


            //Viết SQL
            string deleteAccount = "DELETE ACCOUNT WHERE EMPLOYEEid = '" + Aemployee_ID + "' AND ROLEid = '" + Arole_ID + "'";
            SqlCommand querydeleteAccount = new SqlCommand(deleteAccount, ketnoi);

            try
            {
                querydeleteAccount.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xoá tài khoản thành công !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi xoá tài khoản !\nVui lòng kiểm tra lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListAccountviewInfo();
        }
        #endregion

        #region Cập nhật tài khoản
        private void btUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Aemployee_ID = int.Parse(tbIDEmployee.Text.ToString());
            int Arole_ID;
            string temp = cbRole.Text.ToString();
            if (temp == "Người quản lí")
            {
                Arole_ID = 0;
            }
            else
            {
                Arole_ID = 1;
            }

            string Ausername = tbUsername.Text.ToString();
            string Apassword = tbPassword.Password.ToString();
            string Aconfirm_pass = tbPassConfirm.Password.ToString();
            while (Apassword != Aconfirm_pass)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Mật khẩu không giống nhau !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                tbPassword.Focus();
            }

            //Viết SQL
            string updateAccount = "UPDATE ACCOUNT " +
                                    "SET ROLEid = '" + Arole_ID + "', USERNAME = N'" + Ausername + "', PASSWORD = N'" + Apassword + "' " +
                                    "WHERE EMPLOYEEid = '" + Aemployee_ID + "'";
            SqlCommand queryupdateAccount = new SqlCommand(updateAccount, ketnoi);

            try
            {
                queryupdateAccount.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Cập nhật tài khoản thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi cập nhật tài khoản !\nVui lòng kiểm tra lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListAccountviewInfo();
        }
        #endregion

        #region View Account
        private void btViewAccount_Click(object sender, RoutedEventArgs e)
        {
            ListAccountviewInfo();
        }

        private void lvAccount_Loaded(object sender, RoutedEventArgs e)
        {
            ListAccountviewInfo();
        }

        public void ListAccountviewInfo()
        {
            List<Account> a = new List<Account>();
            bool check = SQL.getListAccount(ref a);
            if (check)
            {
                lvAccount.ItemsSource = a;
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi loading!!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }

        private void lvAccount_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            QLQA.Model.Account row_selected = gd.SelectedItem as QLQA.Model.Account;
            if (row_selected != null)
            {
                tbIDEmployee.Text = row_selected.EMPLOYEEID.ToString();
                tbUsername.Text = row_selected.USERNAME.ToString();
                tbPassword.Password = row_selected.PASSWORD.ToString();
                string role = row_selected.USERROLE.ToString();
                cbRole.Text = role;
            }
        }

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
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                this.tbPassword.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public WindowState WindowState { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        #endregion
    }
}
