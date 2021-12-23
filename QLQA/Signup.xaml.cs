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
using MaterialDesignThemes.Wpf;
using System.Security.Cryptography;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class signup : Window
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        #endregion
        public signup()
        {
            InitializeComponent();
        }

        #region Control Panel 
        private void btexit_Click(object sender, RoutedEventArgs e)
        {
            login lg = new login();
            App.swapMainWindow(lg);
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region check textbox
        private bool check_signup()
        {
            if(!string.IsNullOrEmpty(tbFullName.Text) && !string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPasswordbox.Password) && !string.IsNullOrEmpty(tbPhone.Text))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region bt Đăng ký
        private void btSignup_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            string fullname, user, pass, phone, email;
            int role_ID = 1;

            if (check_signup() && tbPasswordbox.Password.Length >= 8)
            {
                fullname = tbFullName.Text.ToString();
                user = tbUsername.Text.ToString();
                pass = ChangeToMD5(tbPasswordbox.Password.ToString());
                phone = tbPhone.Text.ToString();
                email = tbEmail.Text.ToString();
                role_ID = 1;
            }
            else 
            {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Bạn chưa nhập đầy đủ thông tin hoặc mật khẩu chưa đủ 8 ký tự !");
                    QLQA.Notification.WrongPass dia = new QLQA.Notification.WrongPass();
                    dia.DataContext = a;
                    DialogHost.Show(dia, "signup");
                    return;
            }    
                
            
            #region Random ID nhân viên
            int employee_ID;
            do
            {
                Random r = new Random();
                employee_ID = r.Next(0, 10000);
            } while (SQL.checkEmployeeID(employee_ID));
            #endregion

            #region Lưu nhân viên và lưu tài khoản
            string saveEmployee = "insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('"
                                + employee_ID + "', N'" + fullname + "', N'" + "Nhân viên" + "', N'" + "" + "', N'" + phone + "', N'" + "" + "', N'" + email + "');";
            SqlCommand querysaveEmployee = new SqlCommand(saveEmployee, ketnoi);

            string saveAccount = "INSERT INTO ACCOUNT(EMPLOYEEid,ROLEid,USERNAME,PASSWORD) values (N'" + employee_ID + "', N'" + role_ID + "', N'" + user + "', N'" + pass + "');";
            SqlCommand querysaveAccount = new SqlCommand(saveAccount, ketnoi);
            try
            {
                querysaveEmployee.ExecuteNonQuery();
                querysaveAccount.ExecuteNonQuery();

                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Đăng ký thành công!");
                QLQA.Notification.WrongPass dia = new QLQA.Notification.WrongPass();
                dia.DataContext = a;
                DialogHost.Show(dia, "signup");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi " + es.Message + "");
                QLQA.Notification.WrongPass dia = new QLQA.Notification.WrongPass();
                dia.DataContext = a;
                DialogHost.Show(dia, "signup");
            }
            #endregion
        }

        #endregion

        #region MD5
        public string ChangeToMD5(string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";

            foreach (var item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }
        #endregion

        #region hyperink đăng nhập
        private void btlogin_Click_1(object sender, RoutedEventArgs e)
        {
            login lg = new login();
            App.swapMainWindow(lg);
        }
        #endregion
    }
}
