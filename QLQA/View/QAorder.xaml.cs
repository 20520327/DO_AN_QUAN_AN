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
    /// Interaction logic for QAorder.xaml
    /// </summary>
    public partial class QAorder : UserControl
    {
        #region Các biến toàn cục và chuỗi kết nối
        
        public static int selectedTable = 0;
        public static float thanhtien = 0;
        public static bool IsTT = false;
        public static bool confirm = false;
        public static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public WindowState WindowState { get; private set; }
        #endregion
        public QAorder()
        {
            InitializeComponent();
        }

        #region Control Panel và Home button
        private void Minimize_Click_1(object sender, RoutedEventArgs e)
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

        #region Cập nhật order
        public void update_table()
        {

            #region Đồng bộ bàn
            this.enviroment.Children.Clear();
            List<QLQA.Model.Table> ls = new List<QLQA.Model.Table>();
            bool check = SQL.getListTable(ref ls);
            List<string> lsTable = new List<string>();
            foreach (var temp in ls)
            {
                var a = new addTable(this);
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
            #endregion

            #region Đồng bộ danh mục 
            //Combobox Category
            List<QLQA.Model.Category> lsCate = new List<Category>();
            bool check_Cate = SQL.getListCategory(ref lsCate);
            List<string> lsCategory = new List<string>();
            foreach (var tmp in lsCate)
                lsCategory.Add(tmp.NAME);
            cbCategory.ItemsSource = lsCategory;
            cbCategory.SelectedIndex = 0;
            #endregion
        }
        #endregion

        #region Load form
        private void Window_Loaded(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is OrderView)
            {
                this.enviroment.Children.Clear();
                update_table();
            }
        }
        #endregion

        #region View món ăn
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Các biến và chuỗi kết nối
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Cateid = 0;
            string tempcb = cbCategory.SelectedItem.ToString();
            #endregion

            #region Load danh sách danh mục
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
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi tìm kiếm id category !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            ketnoi.Close();
            #endregion

            #region Load danh sách món ăn
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
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi load danh sách món ăn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            cbFood.ItemsSource = lsFoodName;
            cbFood.SelectedIndex = 0;
            #endregion
        }
        #endregion

        #region Lấy ID món ăn
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

                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không tìm được id món ăn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            return -1;
        }
        #endregion

        #region Tổng đơn hàng
        private int Sum(List<Orderinfo> ls)
        {
            int sum = 0;
            foreach (var tmp in ls)
            {
                sum += tmp.TOTAL1;
            }
            return sum;
        }
        #endregion

        #region Cập nhật lại datagrid để xem danh sách món ăn mỗi bàn
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
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không load được hoá đơn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
        }
        #endregion

        #region Lấy thông tin

        #region Lấy giờ vào bàn
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
                return a.ToString("");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi lấy thời gian vào bàn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            return null;
        }
        #endregion

        #region Tổng tiền
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
        #endregion

        #region Lấy chi tiết đơn hàng
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
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi lấy thông tin đơn hàng của bàn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            return ls;
        }
        #endregion

        #region Lấy ID hoá đơn đã bàn thanh toán
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
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi lấy ID order của bàn đã thanh toán !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            return -1;
        }
        #endregion

        #region Lấy ID hoá đơn bàn chưa thánh toán
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
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi lấy ID order của bàn chưa thanh toán !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            return -1;
        }
        #endregion

        #endregion

        #region Các button

        #region bt Thêm món ăn vô đơn hàng
        private void btAddfood_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);

            List<Orderinfo> ls1 = getListInfoBill(selectedTable);
            #region Trường hợp nếu bàn đó chưa có người
            if (ls1.Count() == 0)
            {
                #region Thêm hoá đơn
                ketnoi.Open();
                string TaoHD = "INSERT INTO ORDER_QA(TABLEid,CHECKIN) VALUES ('" + selectedTable + "','" + DateTime.Now.ToString("") + "')";
                SqlCommand caulenh = new SqlCommand(TaoHD, ketnoi);
                try
                {
                    caulenh.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thêm hoá đơn !");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "main");
                }
                #endregion

                #region Thêm chi tiết đơn
                string addFood = "insert into ORDER_FOOD (ORDERid, FOODid, QUANTITY) values ('" + getIDorderofTable(selectedTable) + "','" + getIDofFood(cbFood.Text.ToString()) + "','" + cbAmout.Text.ToString() + "')";
                SqlCommand caulenh2 = new SqlCommand(addFood, ketnoi);
                try
                {
                    caulenh2.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thêm hoá đơn !");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "main");
                }
                ketnoi.Close();
                #endregion

                #region Cập nhật bàn
                ketnoi.Open();
                string updateTable_2 = "update TABLEQA set STATUS = N'Có người' where ID in ((select TABLEid from ORDER_QA where BILLstatus = '0'))";
                SqlCommand caulenh6 = new SqlCommand(updateTable_2, ketnoi);
                try
                {
                    caulenh6.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi cập nhật người ở bàn !");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "main");
                }
                ketnoi.Close();
                update_table();
                #endregion
            }
            #endregion

            #region Trường hợp đã có người
            else
            {
                #region Nếu món ăn đã tồn tại
                bool checkExist = false;
                foreach (var tmp in ls1)
                {
                    if (tmp.FOODid1 == getIDofFood(cbFood.Text))
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
                            QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thêm món ăn !");
                            QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                            b.DataContext = a;
                            DialogHost.Show(b, "main");
                        }
                        ketnoi.Close();
                    }
                }
                #endregion

                #region Nếu món ăn không tồn tại
                if (!checkExist)
                {
                    ketnoi.Open();
                    checkExist = true;
                    string updateHD = "INSERT ORDER_FOOD (ORDERid, FOODid, QUANTITY) VALUES ('" + getIDorderofTable(selectedTable) + "','" + getIDofFood(cbFood.Text.ToString()) + "','" + int.Parse(cbAmout.Text.ToString()) + "')";
                    SqlCommand caulenh3 = new SqlCommand(updateHD, ketnoi);
                    try
                    {
                        caulenh3.ExecuteNonQuery();
                    }
                    catch (Exception es)
                    {
                        QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thêm món ăn !");
                        QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                        b.DataContext = a;
                        DialogHost.Show(b, "main");
                    }
                    ketnoi.Close();
                }
                update_table();
            }
            updateDataGrid();
            #endregion
            #endregion
        }
        #endregion

        #region bt Thanh toán
        private async void btCheckout_Click(object sender, RoutedEventArgs e)
        {
            Order or = new Order();
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int id_order = getIDorderofTable(selectedTable);
            int total = TotalMoneyOfBill(id_order);

            or.ID = id_order;
            or.TABLE = selectedTable.ToString();
            or.CHECKIN = DateTime.Parse(getCheckInOfOrder(id_order));
            or.CHECKOUT = DateTime.Now;
            or.Info = getListInfoBill(selectedTable);
            or.TOTAL = total;

            QLQA.View.BillInfo bill = new QLQA.View.BillInfo();
            bill.DataContext = or;
            await DialogHost.Show(bill, "main");

            if(IsTT)
            {
                #region Cập nhật bàn đó đã đc thanh toán
                string payoff = "UPDATE ORDER_QA SET BILLstatus = '1', CHECKOUT = '" + DateTime.Now.ToString("") + "' WHERE ID = '" + id_order + "'";
                string updateTable_1 = "update TABLEQA set STATUS = N'Bàn trống' where ID = '" + selectedTable + "'";
                SqlCommand caulenh1 = new SqlCommand(payoff, ketnoi);
                SqlCommand caulenh2 = new SqlCommand(updateTable_1, ketnoi);
                try
                {
                    caulenh1.ExecuteNonQuery();
                    caulenh2.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thanh toán !");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "main");
                }

                updateDataGrid();
                update_table();

                ketnoi.Close();
                #endregion

                #region Thêm vào lịch sử đơn hàng
                ketnoi.Open();
                string addRevenue = "INSERT INTO REVENUE(ORDERid,CHECKIN,CHECKOUT,TOTAL) VALUES ('" + id_order + "','" +
                                    getCheckInOfOrder(id_order) + "','" + DateTime.Now.ToString("") + "','" + total + "')";
                SqlCommand caulenh3 = new SqlCommand(addRevenue, ketnoi);
                try
                {
                    caulenh3.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi thanh toán!\nCần thêm món ăn!");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "main");
                }
                ketnoi.Close();
                IsTT = false;
        }
            else
            {
                return;
            }
            #endregion
            }
        #endregion

        #region bt Đổi bàn 
        private void btSwapTable_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);

            int id_table_swaped = addTable.getIDOfTable(cbTable.Text);
            if(selectedTable == id_table_swaped)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Không thể chuyển cùng bàn");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
                return;
            }
            #region Lấy danh sách hoá đơn của 2 bàn
            List<Orderinfo> ls1 = getListInfoBill(selectedTable);
            List<Orderinfo> ls2 = getListInfoBill(id_table_swaped);
            int ID_order = 0;
            int id_table = 0;
            #endregion

            #region Nếu cả 2 bàn đều không có người
            if (ls1.Count == 0 && ls2.Count == 0)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Cả 2 bàn đều chưa có người.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
                return;
            }
            #endregion

            #region Nếu bàn cần chuyển qua bàn chưa có người
            if (ls2.Count == 0 && ls1.Count != 0)
            {
                //QLQA.Notification.ViewModel.ViewModel mess = new QLQA.Notification.ViewModel.ViewModel("Bạn có muốn chuyển từ bàn " + selectedTable + " qua bàn " + id_table_swaped + " không ?");
                //QLQA.Notification.Check dia = new QLQA.Notification.Check();
                //dia.DataContext = mess;
                //DialogHost.Show(dia, "main");
                //var result = await DialogHost.Show(dia, "main");
                //if (confirm)
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
                        QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi cập nhật chuyển bàn !");
                        QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                        b.DataContext = a;
                        DialogHost.Show(b, "main");
                    }
                    ketnoi.Close();
                }
            }
            #endregion

            #region Nếu bàn chuyển qua bàn có người
            else
            {
                //QLQA.Notification.ViewModel.ViewModel mess = new QLQA.Notification.ViewModel.ViewModel("Bạn có muốn chuyển từ bàn " + selectedTable + " qua bàn " + id_table_swaped + " không ?");
                //QLQA.Notification.Check dia = new QLQA.Notification.Check();
                //dia.DataContext = mess;
                //DialogHost.Show(dia, "main");
                //if (confirm)
                bool passed;
                {
                    #region Duyệt danh sách từ bàn 1 qua bàn 2
                    foreach (var tmp_1 in ls1)
                    {
                        passed = false;
                        ID_order = int.Parse(tmp_1.OrderID1.ToString());
                        foreach (var tmp_2 in ls2)
                        { 
                            
                            #region Nếu món ăn bàn 1 của giống bàn 2
                            if (tmp_1.FOODid1 == tmp_2.FOODid1 && !passed)
                            {
                                passed = true;
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
                                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi cập nhật chuyển bàn !");
                                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                                    b.DataContext = a;
                                    DialogHost.Show(b, "main");
                                }
                                ketnoi.Close();
                            }
                            #endregion

                            #region Nếu món ăn bàn 1 không có ở bàn 2
                            else if(!passed)
                            {
                                passed = true;
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
                                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi cập nhật chuyển bàn !");
                                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                                    b.DataContext = a;
                                    DialogHost.Show(b, "main");
                                }
                                ketnoi.Close();
                            }
                            #endregion
                        }
                        #region Dọn bàn 1
                        ketnoi.Open();
                        string delHd = "DELETE ORDER_FOOD WHERE FOODid = '" + tmp_1.FOODid1 + "' AND ORDERid = '" + tmp_1.OrderID1 + "'";
                        SqlCommand caulenh3 = new SqlCommand(delHd, ketnoi);
                        try
                        {
                            caulenh3.ExecuteNonQuery();
                        }
                        catch (Exception es)
                        {
                            QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi xoá món ăn hoá đơn bàn cũ !");
                            QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                            b.DataContext = a;
                            DialogHost.Show(b, "main");
                        }
                        ketnoi.Close();
                        #endregion
                    }
                    #endregion

                    #region Xoá hoá đơn cũ của bàn cũ
                    ketnoi.Open();
                    string delORDER = "DELETE ORDER_QA WHERE ID = '" + ID_order + "'";
                    SqlCommand caulenh4 = new SqlCommand(delORDER, ketnoi);
                    try
                    {
                        caulenh4.ExecuteNonQuery();
                    }
                    catch (Exception es)
                    {
                        QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi xoá hoá đơn bàn cũ !");
                        QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                        b.DataContext = a;
                        DialogHost.Show(b, "main");
                    }
                    ketnoi.Close();
                    #endregion}
                }
            }
            #endregion
            //Cập nhật bàn
            #region Cập nhật bàn
            ketnoi.Open();
            string updateTable_1 = "update TABLEQA set STATUS = N'Bàn trống' where ID = '" + selectedTable + "'";
            string updateTable_2 = "update TABLEQA set STATUS = N'Có người' where ID in ((select TABLEid from ORDER_QA where BILLstatus = '0'))";
            SqlCommand caulenh5 = new SqlCommand(updateTable_1, ketnoi);
            SqlCommand caulenh6 = new SqlCommand(updateTable_2, ketnoi);
            try
            {
                caulenh5.ExecuteNonQuery();
                caulenh6.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Chuyển bàn thành công !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi cập nhật chuyển bàn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "main");
            }
            ketnoi.Close();
            update_table();
            #endregion
            //Trả lại biến confirm
            confirm = false;
        }
        
        #endregion
    }
    #endregion
}

