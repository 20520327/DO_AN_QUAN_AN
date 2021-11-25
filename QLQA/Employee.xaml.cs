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
    public partial class employee : Window
    {
        public employee()
        {
            InitializeComponent();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Function
        private void btEadd_Click(object sender, RoutedEventArgs e)
        {
            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();
            
            string saveEmployee = "";
            SqlCommand querysaveEmployee = new SqlCommand(saveEmployee);

            try
            {
                querysaveEmployee.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi thêm nhân viên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListEmployeeviewInfo();
        }

        public void ListEmployeeviewInfo()
        {
            List<Employee> a = new List<Employee>();
            bool check = SQL.getListEmployee(ref a);
            if (check)
            {
                lvEmployee.ItemsSource = a;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvEmployee.ItemsSource);
            }
            else
            {
                MessageBox.Show("Lỗi loading!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            ListEmployeeviewInfo();
        }

        private void btEdel_Click(object sender, RoutedEventArgs e)
        {
            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();

            string deleteEmployee = "";
            SqlCommand querydelEmployee = new SqlCommand(deleteEmployee);

            try
            {
                querydelEmployee.ExecuteNonQuery();
                MessageBox.Show("Xoá nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi xoá nhân viên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListEmployeeviewInfo();
        }

        private void btEupdate_Click_1(object sender, RoutedEventArgs e)
        {
            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();

            string UpdateEmployee = "";
            SqlCommand queryUpdateEmployee = new SqlCommand(UpdateEmployee);

            try
            {
                queryUpdateEmployee.ExecuteNonQuery();
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi cập nhật nhân viên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListEmployeeviewInfo();
        }

        private void btEsearch_Click(object sender, RoutedEventArgs e)
        {
            string timkiem = tbEsearch.Text.ToString();
            string SearchEmployee = "'" + timkiem + "%'";
            SqlCommand querySearchEmployee = new SqlCommand(SearchEmployee);

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(querySearchEmployee))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    lvEmployee.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi tìm kiếm món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
