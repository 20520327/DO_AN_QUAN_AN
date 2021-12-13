using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI;

namespace QLQA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void swapMainWindow(Window a)
        {
            Window old = App.Current.MainWindow;
            App.Current.MainWindow = a;
            a.Show();
            old.Close();
            Console.WriteLine("Swap Window");
        }
        public void start(object sender, StartupEventArgs e)
        {
            login a = new login();
            a.Show();
        }
    }
}
