using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace QLQA.View
{
    /// <summary>
    /// Interaction logic for QAWindow.xaml
    /// </summary>
    public partial class QAWindow : Window
    {
        public static QAWindow Instance;

        public QAWindow()
        {
            Instance = this;
            InitializeComponent();
            DataContext = App.Current.FindResource("MaintableView");
        }
    }
}
