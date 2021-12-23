﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using MaterialDesignThemes.Wpf;
using QLQA;
using QLQA.View;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class login : Window, INotifyPropertyChanged
    {
        public login()
        {
            InitializeComponent();
        }

        

        #region Control Panel
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Thuvien.exit();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Sign up button
        private void btsignup_Click(object sender, RoutedEventArgs e)
        {
            signup lg = new signup();
            App.swapMainWindow(lg);
            this.Close();
        }
        #endregion

        #region MD5
        public string ChangeToMD5 (string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";

            foreach (var item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }
        #endregion

        #region Login
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string User = tbUsername.Text.ToString();
            string Pass = tbPassword.Password.ToString();

            string hasPass = ChangeToMD5(Pass);

            if (SQL.CheckLogin(User, hasPass))
            {
                QAWindow a = new QAWindow();
                App.swapMainWindow(a);
            }
            else if (tbUsername.Text.ToString() == "" || tbPassword.Password.ToString() == "")
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Bạn chưa nhập thông tin.\nVui lòng nhập vào.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "login");
            }
            else
            {
                QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Sai mật khẩu hoặc tài khoản!\nVui lòng nhập lại.");
                QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                b.DataContext = a;
                DialogHost.Show(b, "login");
            }
        }

        

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string User = tbUsername.Text.ToString();
                string Pass = tbPassword.Password.ToString();

                string hasPass = ChangeToMD5(Pass);

                if (SQL.CheckLogin(User, hasPass))
                {
                    QAWindow a = new QAWindow();
                    App.swapMainWindow(a);
                }
                else if (tbUsername.Text.ToString() == "" || tbPassword.Password.ToString() == "")
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Bạn chưa nhập thông tin.\nVui lòng nhập vào.");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "login");
                }
                else
                {
                    QLQA.Notification.ViewModel.ViewModel a = new QLQA.Notification.ViewModel.ViewModel("Sai mật khẩu hoặc tài khoản!\nVui lòng nhập lại.");
                    QLQA.Notification.WrongPass b = new QLQA.Notification.WrongPass();
                    b.DataContext = a;
                    DialogHost.Show(b, "login");
                }
            }
        }
        #endregion

        #region Pass peek
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            //Thông báo pass thay đổi để check cập nhật đúng cho cái textbox
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Unsee_Checked(object sender, RoutedEventArgs e)
        {
            this.tbPassword.Visibility = Visibility.Hidden;
            Unmask_pass.Visibility = Visibility.Visible;
        }

        private void Unsee_Unchecked(object sender, RoutedEventArgs e)
        {
            this.tbPassword.Visibility = Visibility.Visible;
            Unmask_pass.Visibility = Visibility.Hidden;
        }

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.CompareOrdinal(Unmask_pass.Text, this.tbPassword.Password) == 0)
                return;
            Unmask_pass.Text = this.tbPassword.Password;
        }
        private void Unmask_pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.CompareOrdinal(Unmask_pass.Text, this.tbPassword.Password) == 0)
                return;
            this.tbPassword.Password = Unmask_pass.Text;
        }

        #endregion
    }

}
