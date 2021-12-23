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
    /// Interaction logic for QAfood.xaml
    /// </summary>
    public partial class QAfood : UserControl
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public WindowState WindowState { get; private set; }
        #endregion
        public QAfood()
        {
            InitializeComponent();
        }


        #region Control Panel and Home button
        //Các nút thoát và minimize
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion
        //Function các nút

        #region Tìm kiếm món ăn
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
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi tìm kiếm món ăn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi tìm kiếm món ăn !");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = dia;
                    DialogHost.Show(b, "main");
                }
            }
        }

        #endregion

        #region Lấy ID danh mục
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
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi truy vấn ID danh mục !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            return tcateid;
        }
        #endregion

        #region View món ăn
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
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi loading!!!");
                QLQA.Notification.WrongPass c = new QLQA.Notification.WrongPass();
                c.DataContext = dia;
                DialogHost.Show(c, "main");
            }
        }

        private void lvFood_Loaded(object sender, RoutedEventArgs e)
        {
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
        #endregion

        #region Thêm món ăn
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            #region Các biến and chuỗi kết nối
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            int tcateid = getIDCategory(tcategory);
            int tmoney;
            #endregion
            //Lấy id category
            #region Xác định danh mục

            if (tcateid == -1)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi xác định danh mục !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            #endregion

            #region Check tiền

            if (!int.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Giá tiền không hợp lệ !!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }
            #endregion

            #region SQL Thêm món
            string saveFood = "INSERT INTO FOOD(ID,NAME,CATEid,PRICE) VALUES (N'" + tid + "', N'" + tname + "', N'" + tcateid + "', N'" + tmoney + "');";
            SqlCommand querysaveFood = new SqlCommand(saveFood, ketnoi);

            try
            {
                querysaveFood.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Thêm món ăn thành công !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi thêm món ăn!\nXin hãy kiểm tra lại thông tin món ăn.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            #endregion
            ListFoodviewInfo();
        }
        #endregion

        #region Xoá món ăn
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            #region Các biến và chuỗi kết nối
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            int tmoney;
            #endregion

            #region Check giá tiền
            if (!int.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Giá tiền không hợp lệ !!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }
            #endregion

            #region SQL và cập nhật view
            string delFood = "DELETE FROM FOOD WHERE ID = '" + tid + "'";
            SqlCommand querydelFood = new SqlCommand(delFood, ketnoi);

            try
            {
                querydelFood.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xoá món ăn thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi xoá món ăn!\nXin hãy kiểm tra lại thông tin món ăn.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListFoodviewInfo();
            #endregion
        }
        #endregion

        #region Cập nhật món ăn
        private void BtUpdate(object sender, RoutedEventArgs e)
        {
            #region các biến và chuỗi kết nối
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int tid = int.Parse(tbID.Text.ToString());
            string tname = tbFoodname.Text.ToString();
            string tcategory = cbCate.Text.ToString();
            float tmoney;
            #endregion

            #region Xác định danh mục
            int tcateid = getIDCategory(tcategory);
            if (tcateid == -1)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi xác định danh mục!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            #endregion

            #region Check giá tiền
            if (!float.TryParse(tbPrice.Text.ToString(), out tmoney))
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Giá tiền không hợp lệ !!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                tbPrice.Clear();
                tbPrice.Focus();
                return;
            }
            #endregion

            #region Cập nhật lại bàn
            string UpdateFood = "UPDATE FOOD " +
                                "SET ID = '" + tid + "', NAME = N'" + tname + "', CATEid = N'" + tcateid + "', PRICE = '" + tmoney + "'" +
                                "WHERE ID = '" + tid + "'";
            SqlCommand queryUpadteFood = new SqlCommand(UpdateFood, ketnoi);
            try
            {
                queryUpadteFood.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Cập nhật món ăn thành công !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi khi cập nhật món ăn!\nXin hãy kiểm tra lại thông tin món ăn.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }

            ListFoodviewInfo();
            #endregion
        }
        #endregion

        
    }
}
