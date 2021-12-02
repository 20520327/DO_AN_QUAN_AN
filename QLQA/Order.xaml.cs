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
        public static int selectedTable = 0;
        public static float thanhtien = 0;
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
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
        public void update_table()
        {
            this.enviroment.Children.Clear();
            List<QLQA.Model.Table> ls = new List<QLQA.Model.Table>();
            bool check = SQL.getListTable(ref ls);
            List<string> lsTable = new List<string>();
            foreach (var temp in ls)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.enviroment.Children.Clear();
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

        public int getIDofFood(string name)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string searchid = "select ID from FOOD where NAME = N'" + name + "'";
            SqlCommand caulenh = new SqlCommand(searchid, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    return kqtruyvan.GetInt32(0);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi không tìm được id bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return -1;
        }

        private int Sum(List<Orderinfo> ls)
        {
            int sum = 0;
            foreach (var tmp in ls)
            {
                sum += tmp.TOTAL1;
            }
            return sum;
        }

        public void updateDataGrid()
        {
            List<Orderinfo> ls = getListInfoBill(selectedTable);
            try
            {
                lvOrder.ItemsSource = ls;
                int total = Sum(ls);
                
                tbTotalMoney.Text = total + "";
            }
            catch (Exception cs)
            {
                MessageBox.Show("Lỗi không load được hoá đơn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btAddfood_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);

            List<Orderinfo> ls1 = getListInfoBill(selectedTable);
            if (ls1.Count() == 0)
            {
                ketnoi.Open();
                string TaoHD = "INSERT INTO ORDER_QA(TABLEid,CHECKIN) VALUES ('" + selectedTable + "','" + DateTime.Now.ToString("h:mm:ss dd/MM/yyyy") + "')";
                SqlCommand caulenh = new SqlCommand(TaoHD, ketnoi);
                try
                {
                    caulenh.ExecuteNonQuery();
                }
                catch(Exception es)
                {
                    MessageBox.Show("Lỗi thêm hoá đơn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                string addFood = "insert into ORDER_FOOD (ORDERid, FOODid, QUANTITY) values ('" + getIDorderofTable(selectedTable) + "','" + getIDofFood(cbFood.Text.ToString()) + "','" + cbAmout.Text.ToString() + "')";
                SqlCommand caulenh2 = new SqlCommand(addFood, ketnoi);
                try
                {
                    caulenh2.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    MessageBox.Show("Lỗi thêm hoá đơn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ketnoi.Close();

                ketnoi.Open();
                string updateTable_2 = "update TABLEQA set STATUS = N'Có người' where ID in ((select TABLEid from ORDER_QA where BILLstatus = '0'))";
                SqlCommand caulenh6 = new SqlCommand(updateTable_2, ketnoi);
                try
                {
                    caulenh6.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ketnoi.Close();
                update_table();
            }
            else
            {
                bool checkExist = false;
                foreach(var tmp  in ls1)
                {
                    if(tmp.FOODid1 == getIDofFood(cbFood.Text))
                    {
                        ketnoi.Open();
                        checkExist = true;
                        string updateHD = "UPDATE ORDER_FOOD SET QUANTITY = '" + (tmp.QUATITY1 + int.Parse(cbAmout.Text.ToString())) + "' WHERE ORDERid = '" + getIDorderofTable(selectedTable) + "' AND FOODid = '" + getIDofFood(cbFood.Text.ToString()) + "'";
                        SqlCommand caulenh3 = new SqlCommand(updateHD, ketnoi);
                        try
                        {
                            caulenh3.ExecuteNonQuery();
                        }
                        catch (Exception es)
                        {
                            MessageBox.Show("Lỗi thêm món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        ketnoi.Close();
                    }
                }

                if (!checkExist)
                {
                    ketnoi.Open();
                    checkExist = true;
                    string updateHD = "INSERT ORDER_FOOD (ORDERid, FOODid, QUANTITY) VALUES ('" + getIDorderofTable(selectedTable) + "','" + getIDofFood(cbFood.Text.ToString()) + "','" +  int.Parse(cbAmout.Text.ToString()) + "')";
                    SqlCommand caulenh3 = new SqlCommand(updateHD, ketnoi);
                    try
                    {
                        caulenh3.ExecuteNonQuery();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show("Lỗi thêm món ăn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    ketnoi.Close();
                }
                update_table();
            }
            updateDataGrid();
        }

        public string getCheckInOfOrder(int ID)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            SqlCommand caulenh = new SqlCommand("select CHECKIN from ORDER_QA WHERE ID = '" + ID + "'", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                DateTime a = new DateTime();
                while (kqtruyvan.Read())
                {
                    a = kqtruyvan.GetDateTime(0);
                } 
                return a.ToString("HH:mm:ss dd/MM/yyyy");
            }
            catch(Exception es)
            {
                MessageBox.Show("Lỗi Lấy thời gian vào bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return null;
        }

        public int TotalMoneyOfBill(int ID)
        {
            List<Orderinfo> ls = getListInfoBill(selectedTable);
            int sum = 0;
            foreach (var tmp in ls)
            {
                sum += tmp.TOTAL1;
            }
            return sum;
        }

        private void btCheckout_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            
            int id_order = getIDorderofTable(selectedTable);
            int total = TotalMoneyOfBill(id_order);

            
            string payoff = "UPDATE ORDER_QA SET BILLstatus = '1', CHECKOUT = '" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "' WHERE ID = '" + id_order + "'";
            string updateTable_1 = "update TABLEQA set STATUS = N'Bàn trống' where ID = '" + selectedTable + "'";
            SqlCommand caulenh1 = new SqlCommand(payoff, ketnoi);
            SqlCommand caulenh2 = new SqlCommand(updateTable_1, ketnoi);
            try
            {
                caulenh1.ExecuteNonQuery();
                caulenh2.ExecuteNonQuery();
            }
            catch(Exception es)
            {
                MessageBox.Show("Lỗi thanh toán !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            updateDataGrid();
            update_table();
            
            ketnoi.Close();

            ketnoi.Open();
            string addRevenue = "INSERT INTO REVENUE(ORDERid,CHECKIN,CHECKOUT,TOTAL) VALUES ('" + id_order + "','" + 
                                getCheckInOfOrder(id_order) + "','" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "','" + total + "')";
            SqlCommand caulenh3 = new SqlCommand(addRevenue, ketnoi);
            try
            {
                caulenh3.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi thanh toán!\nCần thêm món ăn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ketnoi.Close();
        }

        public List<Orderinfo> getListInfoBill(int id_table)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            List<Orderinfo> ls = new List<Orderinfo>();

            string searchInfo = "select A.ID,B.FOODid,B.QUANTITY from (ORDER_QA A inner join ORDER_FOOD B on A.ID=B.ORDERid) where A.TABLEid = '" + id_table + "' and A.BILLstatus = '0'";
            SqlCommand caulenh = new SqlCommand(searchInfo, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Orderinfo a = new Orderinfo();
                    a.OrderID1 = kqtruyvan.GetInt32(0);
                    a.FOODid1 = kqtruyvan.GetInt32(1);
                    a.FOODname1 = addTable.getNameOfFood(a.FOODid1);
                    a.PRICE1 = addTable.getPriceOfFood(a.FOODid1);
                    a.QUATITY1 = kqtruyvan.GetInt32(2);
                    a.TOTAL1 = a.PRICE1 * a.QUATITY1;
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi load được id bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ls;
        }

        public int getIDorderofTable_ThanhToan(int IDtable)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            string searchIDorder = "SELECT ID FROM ORDER_QA  WHERE TABLEid = '" + IDtable + "' AND BILLstatus = '" + 1 + "'";
            SqlCommand caulenh = new SqlCommand(searchIDorder, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    return kqtruyvan.GetInt32(0);
                };
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi lấy ID order của bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return -1;
        }

        public int getIDorderofTable(int IDtable)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            string searchIDorder = "SELECT ID FROM ORDER_QA  WHERE TABLEid = '" + IDtable + "' AND BILLstatus = '" + 0 + "'";
            SqlCommand caulenh = new SqlCommand(searchIDorder, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    return kqtruyvan.GetInt32(0);
                };
            }
            catch(Exception es)
            {
                MessageBox.Show("Lỗi lấy ID order của bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             return -1;
        }

        private void btSwapTable_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            
            int id_table_swaped = addTable.getIDOfTable(cbTable.Text);
            //Chuyển từ list bàn 1 qua bàn 2
            List<Orderinfo> ls1 = getListInfoBill(selectedTable);
            List<Orderinfo> ls2 = getListInfoBill(id_table_swaped);
                int ID_order = 0;
                int id_table = 0;
            //Tạo hoá đơn bàn chưa có đơn
            if (ls1.Count == 0 && ls2.Count == 0)
            {
                MessageBox.Show("Cả 2 bàn đều chưa có người.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (ls2.Count == 0)
            {
                ketnoi.Open();
                string updateNewTable = "UPDATE ORDER_QA SET TABLEid = '" + id_table_swaped + "' WHERE ID = '" + getIDorderofTable(selectedTable) + "'";
                SqlCommand lenh = new SqlCommand(updateNewTable, ketnoi);
                try
                {
                    lenh.ExecuteNonQuery();
                    
                }
                catch (Exception es)
                {
                    MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ketnoi.Close();
            }
            else
            {
                foreach (var tmp_1 in ls1)
                {
                    ID_order = int.Parse(tmp_1.OrderID1.ToString());

                    foreach (var tmp_2 in ls2)
                    {
                        if (tmp_1.FOODid1 == tmp_2.FOODid1)
                        {
                            //Nếu trùng thì cập nhật và tăng giá trị lên 
                            ketnoi.Open();
                            string updateHD = "UPDATE ORDER_FOOD SET QUANTITY = '" + (tmp_1.QUATITY1 + tmp_2.QUATITY1) + "' WHERE ORDERid = '" + int.Parse(tmp_2.OrderID1.ToString()) + "' AND FOODid = '" + int.Parse(tmp_2.FOODid1.ToString()) + "'";
                            SqlCommand caulenh1 = new SqlCommand(updateHD, ketnoi);
                            try
                            {
                                caulenh1.ExecuteNonQuery();
                            }
                            catch (Exception es)
                            {
                                MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            ketnoi.Close();
                        }
                        else
                        {
                            //Nếu chưa có thì thêm vào
                            ketnoi.Open();
                            string addHD = "INSERT INTO ORDER_FOOD(ORDERid, FOODid, QUANTITY) values ('" + tmp_2.OrderID1 + "', '" + tmp_1.FOODid1 + "','" + tmp_1.QUATITY1 + "')";
                            SqlCommand caulenh2 = new SqlCommand(addHD, ketnoi);
                            try
                            {
                                caulenh2.ExecuteNonQuery();
                            }
                            catch (Exception es)
                            {
                                MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            ketnoi.Close();
                        }
                    }
                    ketnoi.Open();
                    string delHd = "DELETE ORDER_FOOD WHERE FOODid = '" + tmp_1.FOODid1 + "' AND ORDERid = '" + tmp_1.OrderID1 + "'";
                    SqlCommand caulenh3 = new SqlCommand(delHd, ketnoi);
                    try
                    {
                        caulenh3.ExecuteNonQuery();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    ketnoi.Close();
                }
            
            //Xoá hoá đơn
            ketnoi.Open();
            string delORDER = "DELETE ORDER_QA WHERE ID = '" + ID_order + "'";
            SqlCommand caulenh4 = new SqlCommand(delORDER, ketnoi);
            try
            {
                caulenh4.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ketnoi.Close();
            }

            //Cập nhật bàn
            ketnoi.Open();
            string updateTable_1 = "update TABLEQA set STATUS = N'Bàn trống' where ID = '" + selectedTable + "'";
            string updateTable_2 = "update TABLEQA set STATUS = N'Có người' where ID in ((select TABLEid from ORDER_QA where BILLstatus = '0'))";
            SqlCommand caulenh5 = new SqlCommand(updateTable_1, ketnoi);
            SqlCommand caulenh6 = new SqlCommand(updateTable_2, ketnoi);
            try
            {
                caulenh5.ExecuteNonQuery();
                caulenh6.ExecuteNonQuery();
                MessageBox.Show("Chuyển bàn thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi cập nhật chuyển bàn !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ketnoi.Close();
            update_table();
        }
    }
}
