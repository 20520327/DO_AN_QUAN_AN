using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    class Revenue
    {
        private int id;
        private string table_num;
        private float money;
        private string date_checkin;
        private string date_checkout;

        protected int Id { get => id; set => id = value; }
        protected string Table_num { get => table_num; set => table_num = value; }
        protected float Money { get => money; set => money = value; }
        protected string Date_checkin { get => date_checkin; set => date_checkin = value; }
        protected string Date_checkout { get => date_checkout; set => date_checkout = value; }
    }
}
