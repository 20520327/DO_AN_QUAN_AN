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
using QLQA.Model;
using System.Data;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class account : Window
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        #endregion
        public account()
        {
            InitializeComponent();
        }
        #region Control Panel and Home button
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        #endregion

        //function button
        #region Account
        #region Thêm tài khoản

        private void btAddAccount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Aemployee_ID = int.Parse(tbIDEmployee.Text.ToString());
            int Arole_ID;
            string temp = cbRole.Text.ToString();
            if(temp == "Người quản lí")
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
                MessageBox.Show("Mật khẩu không giống nhau !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbPassword.Focus();
                return;
            }

            //Viết SQL
            string saveAccount = "INSERT INTO ACCOUNT(EMPLOYEEid,ROLEid,USERNAME,PASSWORD) values (N'" + Aemployee_ID + "', N'" + Arole_ID + "', N'" + Ausername + "', N'" + Apassword + "');";
            SqlCommand querysaveAccount = new SqlCommand(saveAccount,ketnoi);

            try
            {
                querysaveAccount.ExecuteNonQuery();
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
            string deleteAccount = "DELETE ACCOUNT WHERE EMPLOYEEid = '" + Aemployee_ID + "' AND ROLEid = '" + Arole_ID +"'";
            SqlCommand querydeleteAccount = new SqlCommand(deleteAccount,ketnoi);

            try
            {
                querydeleteAccount.ExecuteNonQuery();
                MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Mật khẩu không giống nhau !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbPassword.Focus();
                return;
            }

            //Viết SQL
            string updateAccount = "UPDATE ACCOUNT " +
                                    "SET ROLEid = '" + Arole_ID + "', USERNAME = N'" + Ausername +"', PASSWORD = N'" + Apassword + "' " +
                                    "WHERE EMPLOYEEid = '" + Aemployee_ID + "'";
            SqlCommand queryupdateAccount = new SqlCommand(updateAccount,ketnoi);

            try
            {
                queryupdateAccount.ExecuteNonQuery();
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Lỗi loading!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                string role = row_selected.USERROLE.ToString();
                if (role == "0")
                {
                    cbRole.Text = "Người quản lí";
                }
                else
                {
                    cbRole.Text = "Nhân viên";
                }
            }
        }
        #endregion

        #endregion
    }
}
