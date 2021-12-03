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
            this.Close();
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region bt Đăng ký
        private void btSignup_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string fullname = tbFullName.Text.ToString();
            string user = tbUsername.Text.ToString();
            string pass = tbPasswordbox.Password.ToString();
            string phone = tbPhone.Text.ToString();
            string email = tbEmail.Text.ToString();
            int role_ID = 1;

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
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            #endregion
        }
        #endregion
    }
}
