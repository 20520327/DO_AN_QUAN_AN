using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace UI
{
    public class Thuvien
    {
        static public void exit()
        {
            Environment.Exit(0);
        }
        static public void minimized()
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
