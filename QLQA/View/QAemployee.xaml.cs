﻿using System;
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
    /// Interaction logic for QAemployee.xaml
    /// </summary>
    public partial class QAemployee : UserControl
    {
        #region Chuỗi kết nối
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";

        public WindowState WindowState { get; private set; }
        #endregion
        public QAemployee()
        {
            InitializeComponent();
        }

        #region Control Panel and Home button
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
        //Function

        #region Thêm nhân viên
        private void btEadd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();

            string saveEmployee = "insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('"
                                + Eid + "', N'" + Ename + "', N'" + Eposition + "', N'" + Eaddress + "', N'" + Ephone + "', N'" + Esex + "', N'" + Eemail + "');";
            SqlCommand querysaveEmployee = new SqlCommand(saveEmployee, ketnoi);

            try
            {
                querysaveEmployee.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Thêm nhân viên thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi " + es.Message + "");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListEmployeeviewInfo();
        }
        #endregion

        #region View Nhân viên
        public void ListEmployeeviewInfo()
        {
            List<Employee> a = new List<Employee>();
            bool check = SQL.getListEmployee(ref a);
            if (check)
            {
                lvEmployee.ItemsSource = a;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvEmployee.ItemsSource);
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Lỗi loading!!!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }
        private void btEview_Click(object sender, RoutedEventArgs e)
        {
            ListEmployeeviewInfo();
        }
        private void lvEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            ListEmployeeviewInfo();
        }
        private void lvEmployee_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            QLQA.Model.Employee row_selected = gd.SelectedItem as QLQA.Model.Employee;
            if (row_selected != null)
            {
                tbID.Text = row_selected.EID.ToString();
                tbName.Text = row_selected.ENAME.ToString();
                tbPosition.Text = row_selected.EPOSITION.ToString();
                tbSex.Text = row_selected.ESEX.ToString();
                tbPhone.Text = row_selected.EPHONE.ToString();
                tbAddress.Text = row_selected.EADDRESS.ToString();
                tbEmail.Text = row_selected.EEMAIL.ToString();
            }
        }

        #endregion

        #region Xoá nhân viên
        private void btEdel_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();

            string deleteEmployee = "DELETE EMPLOYEE WHERE ID = '" + Eid + "'";
            SqlCommand querydelEmployee = new SqlCommand(deleteEmployee, ketnoi);

            try
            {
                querydelEmployee.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xoá nhân viên thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi " + es.Message + "");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListEmployeeviewInfo();
        }
        #endregion

        #region Cập nhật nhân viên
        private void btEupdate_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            int Eid = int.Parse(tbID.Text.ToString());
            string Ename = tbName.Text.ToString();
            string Eposition = tbPosition.Text.ToString();
            string Esex = tbSex.Text.ToString();
            string Ephone = tbPhone.Text.ToString();
            string Eaddress = tbAddress.Text.ToString();
            string Eemail = tbEmail.Text.ToString();

            string UpdateEmployee = "UPDATE EMPLOYEE " +
                "SET ID = N'" + Eid + "', FULLNAME = N'" + Ename + "', POSITION = N'" + Eposition + "', ADDRESS = N'" + Eaddress + "', SEX = N'" + Esex + "', PHONE = N'" + Ephone + "', EMAIL = N'" + Eemail + "' " +
                "WHERE ID = N'" + Eid + "'";
            SqlCommand queryUpdateEmployee = new SqlCommand(UpdateEmployee, ketnoi);


            try
            {
                queryUpdateEmployee.ExecuteNonQuery();
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Cập nhật nhân viên thành công!");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi " + es.Message + "");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
            ListEmployeeviewInfo();
        }
        #endregion

        #region Tìm kiếm nhân viên
        private void btEsearch_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();

            List<Employee> ls = new List<Employee>();

            string timkiem = tbEsearch.Text.ToString();
            string SearchEmployee = "select * from EMPLOYEE where FULLNAME like N'" + timkiem + "%'";
            SqlCommand caulenh = new SqlCommand(SearchEmployee, ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Employee a = new Employee();
                    a.EID = kqtruyvan.GetInt32(0);
                    a.ENAME = kqtruyvan[1].ToString();
                    a.EPOSITION = kqtruyvan[2].ToString();
                    a.EADDRESS = kqtruyvan[3].ToString();
                    a.EPHONE = kqtruyvan[4].ToString();
                    a.ESEX = kqtruyvan[5].ToString();
                    a.EEMAIL = kqtruyvan[6].ToString();
                    ls.Add(a);
                }
                lvEmployee.ItemsSource = ls;
            }
            catch (Exception es)
            {
                QLQA.Notification.ViewModel.ViewModel dia = new QLQA.Notification.ViewModel.ViewModel("Xảy ra lỗi" + es.Message + "");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = dia;
                DialogHost.Show(b, "main");
            }
        }
        #endregion

    }
}
