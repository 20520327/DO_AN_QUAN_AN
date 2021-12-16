using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MaterialDesignThemes.Wpf;
using Microsoft.Reporting.WinForms;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QAreport.xaml
    /// </summary>
    public partial class QAreport : UserControl
    {
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public QAreport()
        {
            InitializeComponent();
        }

        private void btStatisticalTable_Click(object sender, RoutedEventArgs e)
        {
            //ReportDemo.Reset();
            //DataTable dt = GetData();
            //ReportDataSource ds = new ReportDataSource("", dt);
            //ReportDemo.LocalReport.DataSources.Add(ds);
            //ReportDemo.LocalReport.ReportEmbeddedResource = "";
            //ReportDemo.RefreshReport();
        }

        private DataTable GetData()
        {
            DateTime from = dpDayfrom.SelectedDate.Value;
            DateTime to = dpDayto.SelectedDate.Value;

            if (to < from)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Ngày nhập vào không hợp lệ !");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
                return null;
            }

            DataTable dt = new DataTable();
            using(SqlConnection ketnoi = new SqlConnection(Connectionstring))
            {
                string Statistic = "select A.ORDERid,B.TABLEid,A.TOTAL,A.CHECKIN,A.CHECKOUT from REVENUE A INNER JOIN ORDER_QA B ON A.ORDERid = B.ID ";
                SqlCommand caulenh = new SqlCommand(Statistic, ketnoi);
                SqlDataAdapter adp = new SqlDataAdapter(caulenh);
            }
            return dt;
        }
    }
}
