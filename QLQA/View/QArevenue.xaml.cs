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
using System.Data.SqlTypes;
using MaterialDesignThemes.Wpf;
using UI;
using Microsoft.Win32;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QArevenue.xaml
    /// </summary>
    public partial class QArevenue : UserControl
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public WindowState WindowState { get; private set; }
        #endregion
        public QArevenue()
        {
            InitializeComponent();
        }

        #region Control panel and Home button
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        #region Button Thống kê
        private void btStatistical_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            DateTime from = dpDayfrom.SelectedDate.Value;
            DateTime to = dpDateto.SelectedDate.Value;
            if (to < from)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Ngày nhập vào không hợp lệ !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                return;
            }
            List<Revenue> ls = new List<Revenue>();
            string Statistic = "select A.ORDERid,B.TABLEid,A.TOTAL,A.CHECKIN,A.CHECKOUT from REVENUE A INNER JOIN ORDER_QA B ON A.ORDERid = B.ID ";

            SqlCommand caulenh = new SqlCommand(Statistic, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Revenue a = new Revenue();
                    a.Id = kqtruyvan.GetInt32(0);
                    a.Table_num = kqtruyvan[1].ToString();
                    a.Money = kqtruyvan.GetInt32(2);
                    a.Date_checkin = kqtruyvan.GetDateTime(3);
                    a.Date_checkout = kqtruyvan.GetDateTime(4);
                    ls.Add(a);
                }

                ls = ls.Where((obj => {
                    DateTime checkOut = obj.Date_checkout;
                    long checkOutDAY = checkOut.Day;
                    long checkOutMONTH = checkOut.Month;
                    long checkOutYEAR = checkOut.Year;
                    return (from.Day <= checkOutDAY && to.Day >= checkOutDAY) && (from.Month <= checkOutMONTH && to.Month >= checkOutMONTH) && (from.Year <= checkOutYEAR && to.Year >= checkOutYEAR);
                })).ToList();
                lvRevenue.ItemsSource = ls;
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi thống kê !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }
        #endregion

        #region Load bảng thống kê
        private void lvRevenue_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            List<Revenue> ls = new List<Revenue>();
            string Statistic = "select A.ORDERid,B.TABLEid,A.TOTAL,A.CHECKIN,A.CHECKOUT from REVENUE A INNER JOIN ORDER_QA B ON A.ORDERid = B.ID ";
            SqlCommand caulenh = new SqlCommand(Statistic, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Revenue a = new Revenue();
                    a.Id = kqtruyvan.GetInt32(0);
                    a.Table_num = kqtruyvan[1].ToString();
                    a.Money = kqtruyvan.GetInt32(2);
                    a.Date_checkin = kqtruyvan.GetDateTime(3);
                    a.Date_checkout = kqtruyvan.GetDateTime(4);
                    ls.Add(a);
                }
                lvRevenue.ItemsSource = ls;
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi load bảng thống kê !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }
        #endregion

        #region Excel
        private void btExcel_Click(object sender, RoutedEventArgs e)
        {
            lvRevenue.SelectAllCells();
            lvRevenue.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, lvRevenue);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            lvRevenue.UnselectAllCells();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel |*.xls";
            bool check = false;
            if (dpDateto.Text != "")
            {
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\visual studio\Quanliquanan\SQL_quan_li\Baocao_ngay _" + ((DateTime)dpDateto.SelectedDate.Value).Day + "_thang_" + ((DateTime)dpDateto.SelectedDate.Value).Month + "_nam_" + ((DateTime)dpDateto.SelectedDate.Value).Year + ".xls");
                if (save.ShowDialog() == true)
                {
                    check = true;
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"" + save.FileName + "");
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();
                }
                    
            }
            else
            {
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\visual studio\Quanliquanan\SQL_quan_li\Baocaotongquat.xls");
                if(save.ShowDialog() == true)
                {
                    check = true;
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(@""+ save.FileName +"");
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();
                }
            }
            if (check)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Đã lưu báo cáo thành công thành file Excel.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }
        #endregion
    }
}
