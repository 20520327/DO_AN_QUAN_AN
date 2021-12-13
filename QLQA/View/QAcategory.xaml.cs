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
using UI;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QAcategory.xaml
    /// </summary>
    public partial class QAcategory : UserControl
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public WindowState WindowState { get; private set; }
        #endregion
        public QAcategory()
        {
            InitializeComponent();
        }
        #region Control Panel và Home Button
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
        //Function button
        #region Thêm danh mục
        private void btAddCate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int Cid = int.Parse(tbIDCate.Text.ToString());
            string Cname = tbNameCate.Text.ToString();

            string saveCategory = "INSERT INTO CATEGORY(ID,NAME) VALUES ('" + Cid + "', N'" + Cname + "');";
            SqlCommand querysaveCategory = new SqlCommand(saveCategory, ketnoi);

            try
            {
                querysaveCategory.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Thêm danh mục thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi thêm danh mục!\nXin hãy kiểm tra thông tin danh mục.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListCategoryviewInfo();

        }
        #endregion

        #region Xoá danh mục
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
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xoá danh mục thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi xoá danh mục!\nXin hãy kiểm tra thông tin danh mục.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListCategoryviewInfo();
        }
        #endregion

        #region Cập nhật danh mục
        private void btUpdateCate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Cid = int.Parse(tbIDCate.Text.ToString());
            string Cname = tbNameCate.Text.ToString();

            //Làm SQL
            string updateCategory = "UPDATE CATEGORY " +
                "SET ID = N'" + Cid + "', NAME = N'" + Cname + "'" +
                " WHERE ID = '" + Cid + "'";
            SqlCommand queryupdateCategory = new SqlCommand(updateCategory, ketnoi);

            try
            {
                queryupdateCategory.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Cập nhật danh mục thành công !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi cập nhật danh mục!\nXin hãy kiểm tra thông tin danh mục.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListCategoryviewInfo();
        }
        #endregion

        #region View danh mục
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
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi loading!!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
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
        #endregion
    }
}
