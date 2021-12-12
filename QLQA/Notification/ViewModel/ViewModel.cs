using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Notification.ViewModel
{
    class ViewModel
    {
        private string mess;

        public ViewModel(string mess)
        {
            this.mess = mess;
        }

        public string Mess { get => mess; set => mess = value; }
    }
}
