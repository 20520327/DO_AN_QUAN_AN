using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Revenue
    {
        private int id;
        private string table_num;
        private float money;
        private DateTime date_checkin;
        private DateTime date_checkout;

        public int Id { get => id; set => id = value; }
        public string Table_num { get => table_num; set => table_num = value; }
        public float Money { get => money; set => money = value; }
        public DateTime Date_checkin { get => date_checkin; set => date_checkin = value; }
        public DateTime Date_checkout { get => date_checkout; set => date_checkout = value; }
    }
}
