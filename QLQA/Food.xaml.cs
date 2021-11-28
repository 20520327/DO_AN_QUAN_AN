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
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Function các nút
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string timkiem = tbSearch.Text.ToString();
            string Searchfood = "select * from FOOD where NAME LIKE '" + timkiem + "%'";
            SqlCommand querySearchFood = new SqlCommand(Searchfood);

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(querySearchFood))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    lvFood.ItemsSource = dt.DefaultView;
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi tìm kiếm món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ListFoodviewInfo()
        {
            List<Food> a = new List<Food>();
            bool check = SQL.getListFood(ref a);
            if (check)
            {
                lvFood.ItemsSource = a;
                
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            float tmoney;
            while(!float.TryParse(tbPrice.Text.ToString(),out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
            }
            string saveFood = "INSERT INTO FOOD(ID,NAME,CATEid,PRICE) VALUES ('" + tid + "', '" + tname + "', '" + tcategory + "', '" + tmoney + "');";
            SqlCommand querysaveFood = new SqlCommand(saveFood,ketnoi);

            try
            {
                querysaveFood.ExecuteNonQuery();
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi thêm món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }
        //
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            float tmoney;
            while (!float.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
            }

            string delFood = "DELETE FROM FOOD WHERE ID = '" + tid + "'";
            SqlCommand querydelFood = new SqlCommand(delFood);

            try
            {
                querydelFood.ExecuteNonQuery();
                MessageBox.Show("Xoá món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi xoá món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }

        private void BtUpdate(object sender, RoutedEventArgs e)
        {
            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            float tmoney;
            while (!float.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                MessageBox.Show("Giá tiền không hợp lệ !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Clear();
                tbPrice.Focus();
            }

            string UpdateFood = "UPDATE FOOD " + 
                                "SET ID = '" + tid + "', NAME = '" + tname + "', CATEid = '" + tcategory + "', PRICE = '" + tmoney + "'" +
                                "WHERE ID = '" + tid + "'";
            SqlCommand queryUpadteFood = new SqlCommand(UpdateFood);
            try
            {
                queryUpadteFood.ExecuteNonQuery();
                MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi cập nhật món ăn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListFoodviewInfo();
        }

        private void btView_Click(object sender, RoutedEventArgs e)
        {
            ListFoodviewInfo();
        }
    }
}
