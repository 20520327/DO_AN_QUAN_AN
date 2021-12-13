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
using UI;
using System.Data.SqlClient;
using QLQA;
using QLQA.Model;
using System.Data;
using MaterialDesignThemes.Wpf;
using QLQA.View;

namespace QLQA
{
    /// <summary>
    /// Interaction logic for addTable.xaml
    /// </summary>
    public partial class addTable : UserControl
    {
        private QAorder caller;
        public addTable(QAorder caller = null)
        {
            InitializeComponent();
            this.caller = caller;
        }

        #region Table order info

        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        #endregion

        #region Lấy ID bàn
        public static int getIDOfTable(string btname)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string searchid = "select ID from TABLEQA where NAME = N'" + btname + "'";
            SqlCommand caulenh = new SqlCommand(searchid, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    return kqtruyvan.GetInt32(0);
                }
            }
            catch(Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không tìm được id bàn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
            return -1;
        }
        #endregion

        #region Tên món ăn
        public static string getNameOfFood(int ID)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string searchid = "select NAME from FOOD where ID = '" + ID + "'";
            SqlCommand caulenh = new SqlCommand(searchid, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    return kqtruyvan[0].ToString();
                }
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không tìm được tên món ăn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
            return null;
        }
        #endregion

        #region Lấy giá món ăn
        public static int getPriceOfFood(int ID)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            string searchid = "select PRICE from FOOD where ID = '" + ID + "'";
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
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không tìm được giá món ăn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
            return -1;
        }
        #endregion

        #region Lấy danh sách đơn hàng chưa thanh toán
        public List<Orderinfo> getListInfoBill()
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            List<Orderinfo> ls = new List<Orderinfo>();
            
            int id_table = getIDOfTable(Tablename.Text);
            QLQA.View.QAorder.selectedTable = id_table;
            string searchInfo = "select A.ID,B.FOODid,B.QUANTITY from (ORDER_QA A inner join ORDER_FOOD B on A.ID=B.ORDERid) where A.TABLEid = '"+ id_table +"' and A.BILLstatus = '0'";
            SqlCommand caulenh = new SqlCommand(searchInfo, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Orderinfo a = new Orderinfo();
                    a.OrderID1 = kqtruyvan.GetInt32(0);
                    a.FOODid1 = kqtruyvan.GetInt32(1);
                    a.FOODname1 = getNameOfFood(a.FOODid1);
                    a.PRICE1 = getPriceOfFood(a.FOODid1);
                    a.QUATITY1 = kqtruyvan.GetInt32(2);
                    a.TOTAL1 = a.PRICE1 * a.QUATITY1;
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi load được id đơn hàng chưa thanh toán !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
            return ls;
        }
        #endregion

        #region Tổng
        private int Sum(List<Orderinfo> ls)
        {
            int sum = 0;
            foreach(var tmp in ls)
            {
                sum += tmp.TOTAL1;
            }
            return sum;
        }
        #endregion

        #region Cập nhật View đơn hàng
        public void updateDataGrid()
        {

            List<Orderinfo> ls = getListInfoBill();
            try
            {
                caller.lvOrder.ItemsSource = ls;
                int total = Sum(ls);

                caller.tbTotalMoney.Text = total + "";
            }
            catch (Exception cs)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không load được hoá đơn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
        }
        #endregion

        #region View order từng bàn
        private void btTable_Click(object sender, RoutedEventArgs e)
        {
            List<Orderinfo> ls = getListInfoBill();
            try
            {
                caller.lvOrder.ItemsSource = ls;
                int total = Sum(ls);

                caller.tbTotalMoney.Text = total + "";
            }
            catch(Exception cs)
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Lỗi không load được hoá đơn !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b);
            }
        }
        #endregion

        #endregion
    }
}
