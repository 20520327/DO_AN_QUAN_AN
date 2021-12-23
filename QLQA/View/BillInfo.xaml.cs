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

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for BillInfo.xaml
    /// </summary>
    public partial class BillInfo : UserControl
    {
        public BillInfo()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QLQA.View.QAorder.IsTT = true;
            
        }

        private void InPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this,"Thông tin hoá đơn");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
