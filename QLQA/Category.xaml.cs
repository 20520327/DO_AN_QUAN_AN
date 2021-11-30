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
    public partial class category : Window
    {
        public category()
        {
            InitializeComponent();
        }

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

        //Function button
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        private void btAddCate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int Cid = int.Parse(tbIDCate.Text.ToString());
            string Cname = tbNameCate.Text.ToString();

            string saveCategory = "INSERT INTO CATEGORY(ID,NAME) VALUES ('" + Cid + "', N'" + Cname + "');";
            SqlCommand querysaveCategory = new SqlCommand(saveCategory,ketnoi);

            try
            {
                querysaveCategory.ExecuteNonQuery();
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListCategoryviewInfo();

        }

        private void btDelCate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Cid = int.Parse(tbIDCate.Text.ToString());

            string delCategory = "DELETE CATEGORY WHERE ID = '" + Cid + "';";
            SqlCommand querydelCategory = new SqlCommand(delCategory, ketnoi);

            try
            {
                querydelCategory.ExecuteNonQuery();
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListCategoryviewInfo();
        }

        private void btUpdateCate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Cid = int.Parse(tbIDCate.Text.ToString());
            string Cname = tbNameCate.Text.ToString();

            //Làm SQL
            string updateCategory = "UPDATE CATEGORY " +
                "SET ID = N'"+ Cid + "', NAME = N'" + Cname + "'" +
                " WHERE ID = '" + Cid + "'";
            SqlCommand queryupdateCategory = new SqlCommand(updateCategory,ketnoi);

            try
            {
                queryupdateCategory.ExecuteNonQuery();
                MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListCategoryviewInfo();
        }

        private void btViewCate_Click(object sender, RoutedEventArgs e)
        {
            ListCategoryviewInfo();
        }

        private void lvCategory_Loaded(object sender, RoutedEventArgs e)
        {
            ListCategoryviewInfo();
        }

        public void ListCategoryviewInfo()
        {
            List<Category> a = new List<Category>();
            bool check = SQL.getListCategory(ref a);
            if (check)
            {
                lvCategory.ItemsSource = a;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvCategory.ItemsSource);
            }
            else
            {
                MessageBox.Show("Lỗi loading!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvCategory_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            QLQA.Model.Category row_selected = gd.SelectedItem as QLQA.Model.Category;
            if (row_selected != null)
            {
                tbIDCate.Text = row_selected.ID.ToString();
                tbNameCate.Text = row_selected.NAME.ToString();
            }
        }
    }
}
