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
    public partial class order : Window
    {
        public order()
        {
            InitializeComponent();
        }

        private void Minimize_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<QLQA.Model.Table> ls = new List<QLQA.Model.Table>();
            bool check = SQL.getListTable(ref ls);
            List<string> lsTable = new List<string>();
            foreach(var temp in ls)
            {
                var a = new addTable();
                a.Margin = new Thickness(10, 10, 10, 10);
                a.Tablename.Text = temp.NAME;
                if (temp.STATUS == "Có người")
                    a.btTable.Background = Brushes.Purple;
                this.enviroment.Children.Add(a);
                //Thêm list table
                lsTable.Add(temp.NAME);
            }
            //Combobox table
            cbTable.ItemsSource = lsTable;
            cbTable.SelectedIndex = 0;

            //Combobox Category
            List<QLQA.Model.Category> lsCate = new List<Category>();
            bool check_Cate = SQL.getListCategory(ref lsCate);
            List<string> lsCategory = new List<string>();
            foreach (var tmp in lsCate)
                lsCategory.Add(tmp.NAME);
            cbCategory.ItemsSource = lsCategory;
            cbCategory.SelectedIndex = 0;
        }
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Cateid = 0;
            string tempcb = cbCategory.SelectedItem.ToString();
            string searchidcate = "select ID from CATEGORY where NAME = N'" + tempcb + "'";
            SqlCommand caulenh = new SqlCommand(searchidcate, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Cateid = kqtruyvan.GetInt32(0);
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Lỗi tìm kiếm id category !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ketnoi.Close();
            ketnoi.Open();

            List<string> lsFoodName = new List<string>();
            string Searchfood = "select NAME from FOOD where CATEid = '" + Cateid + "'";
            SqlCommand caulenh1 = new SqlCommand(Searchfood, ketnoi);
            SqlDataReader kqtruyvan1 = caulenh1.ExecuteReader();
            try
            {
                while (kqtruyvan1.Read())
                {
                    string tempName = kqtruyvan1[0].ToString();
                    lsFoodName.Add(tempName);
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Lỗi Load danh sách món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            cbFood.ItemsSource = lsFoodName;
            cbFood.SelectedIndex = 0;
        }

        private void btAddfood_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCheckout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
