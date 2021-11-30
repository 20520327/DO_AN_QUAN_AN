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
    public partial class food : Window
    {
        public food()
        {
            InitializeComponent();
        }
        //Các nút thoát và minimize
        private void Minimize_Click(object sender, RoutedEventArgs e)
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
        //Function các nút
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string timkiem = tbSearch.Text.ToString();
            string Searchfood = "select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID where A.NAME LIKE N'" + timkiem + "%'";
            SqlCommand caulenh = new SqlCommand(Searchfood, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();

            List<Food> ls = new List<Food>();
            try
            {
                while (kqtruyvan.Read())
                {
                    Food a = new Food();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.NAME = kqtruyvan[1].ToString();
                    a.CATEGORY_NAME = kqtruyvan[2].ToString();
                    a.PRICE = kqtruyvan.GetInt32(3);
                    ls.Add(a);
                }
                lvFood.ItemsSource = ls;
            }
            catch(Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ListFoodviewInfo()
        {
            List<Food> a = new List<Food>();
            List<Category> b = new List<Category>();
            bool check_1 = SQL.getListFood(ref a);
            bool check_2 = SQL.getListCategory(ref b);
            if (check_1 && check_2)
            {
                lvFood.ItemsSource = a;
                List<string> lsCatename = new List<string>();
                foreach (var tmp in b)
                {
                    lsCatename.Add(tmp.NAME);
                }
                cbCate.ItemsSource = lsCatename;
                cbCate.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Lỗi loading!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvFood_Loaded(object sender, RoutedEventArgs e)
        {
            ListFoodviewInfo();
        }

        private int getIDCategory(string Cate_name)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int tcateid = -1;
            SqlCommand caulenh = new SqlCommand("select ID from CATEGORY where NAME = N'" + Cate_name + "'", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    tcateid = kqtruyvan.GetInt32(0);
                };
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi truy vấn danh mục !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return tcateid;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            //Lấy id category
            int tcateid = getIDCategory(tcategory);
            if(tcateid == -1)
            {
                MessageBox.Show("Lỗi xác định danh mục!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            int tmoney;
            if(!int.TryParse(tbPrice.Text.ToString(),out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }
            string saveFood = "INSERT INTO FOOD(ID,NAME,CATEid,PRICE) VALUES (N'" + tid + "', N'" + tname + "', N'" + tcateid + "', N'" + tmoney + "');";
            SqlCommand querysaveFood = new SqlCommand(saveFood,ketnoi);

            try
            {
                querysaveFood.ExecuteNonQuery();
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception es)
            {
                MessageBox.Show("Xảy ra lỗi " + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }
        //
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            int tmoney;
            if (!int.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }

            string delFood = "DELETE FROM FOOD WHERE ID = '" + tid + "'";
            SqlCommand querydelFood = new SqlCommand(delFood,ketnoi);

            try
            {
                querydelFood.ExecuteNonQuery();
                MessageBox.Show("Xoá món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }

        private void BtUpdate(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            float tmoney;

            int tcateid = getIDCategory(tcategory);
            if (tcateid == -1)
            {
                MessageBox.Show("Lỗi xác định danh mục!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!float.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }

            string UpdateFood = "UPDATE FOOD " + 
                                "SET ID = '" + tid + "', NAME = N'" + tname + "', CATEid = N'" + tcateid + "', PRICE = '" + tmoney + "'" +
                                "WHERE ID = '" + tid + "'";
            SqlCommand queryUpadteFood = new SqlCommand(UpdateFood,ketnoi);
            try
            {
                queryUpadteFood.ExecuteNonQuery();
                MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + "", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }

        private void btView_Click(object sender, RoutedEventArgs e)
        {
            ListFoodviewInfo();
        }

        private void lvFood_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            QLQA.Model.Food row_selected = gd.SelectedItem as QLQA.Model.Food;
            if (row_selected != null)
            {
                tbID.Text = row_selected.ID.ToString();
                tbFoodname.Text = row_selected.NAME.ToString();
                cbCate.SelectedItem = row_selected.CATEGORY_NAME.ToString();
                tbPrice.Text = row_selected.PRICE.ToString();
            }
        }
    }
}
