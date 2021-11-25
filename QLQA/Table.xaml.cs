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
    public partial class table : Window
    {
        public table()
        {
            InitializeComponent();
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ListTableviewInfo()
        {
            List<QLQA.Model.Table> a = new List<QLQA.Model.Table>();
            bool check = SQL.getListTable(ref a);
            if (check)
            {
                lvTable.ItemsSource = a;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvTable.ItemsSource);
            }
            else
            {
                MessageBox.Show("Lỗi loading!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Function các nút 
        private void btAddTable_Click(object sender, RoutedEventArgs e)
        {
            int tid = int.Parse(tbtID.Text.ToString());
            string tname = tbtName.Text.ToString();
            string tstatus = cbtStatus.Text.ToString();
            string saveTable = "INSERT INTO TABLEQA(ID,NAME,STATUS) VALUES ('" + tid + "', '" + tname + "', '" + tstatus + "');";
            SqlCommand querySaveTable = new SqlCommand(saveTable);

            try
            {
                querySaveTable.ExecuteNonQuery();
                MessageBox.Show("Thêm bàn thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi thêm bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListTableviewInfo();
        }

        private void lvTable_Loaded(object sender, RoutedEventArgs e)
        {
            ListTableviewInfo();
        }

        private void btDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            int tid = int.Parse(tbtID.Text.ToString());
            string tname = tbtName.Text.ToString();
            string tstatus = cbtStatus.Text.ToString();
            string DeleteTable = "DELETE FROM TABLEQA WHERE ID = '" + tid + "' OR NAME = '" + tname + "'";
            SqlCommand queryDelTable = new SqlCommand(DeleteTable);
            try
            {
                queryDelTable.ExecuteNonQuery();
                MessageBox.Show("Xoá bàn thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi xoá bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListTableviewInfo();
        }

        private void btUpgradeTable_Click(object sender, RoutedEventArgs e)
        {
            int tid = int.Parse(tbtID.Text.ToString());
            string tname = tbtName.Text.ToString();
            string tstatus = cbtStatus.Text.ToString();
            string UpgradeTable =   "UPDATE TABLEQA " +
                                    "SET ID = '" + tid + "', NAME = '" + tname + "'" + "', STATUS = '" + tstatus + "'" +
                                    "WHERE ID = '" + tid + "' OR NAME = '" + tname + "'";
            SqlCommand queryUpgradeTable = new SqlCommand(UpgradeTable);
            try
            {
                queryUpgradeTable.ExecuteNonQuery();
                MessageBox.Show("Cập nhật bàn thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception es)
            {
                MessageBox.Show("Xảy ra lỗi" + es.Message + " khi cập nhật bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ListTableviewInfo();
        }

        private void btViewTable_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
