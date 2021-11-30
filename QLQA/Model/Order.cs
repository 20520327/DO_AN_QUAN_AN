using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Order
    {
        private int id;
        private string table;
        private DateTime Checkin;
        private DateTime Checkout;
        private List<Orderinfo> info = new List<Orderinfo>();
        private long total;

        public int ID { get => id; set => id = value; }
        public string TABLE { get => table; set => table = value; }
        public DateTime CHECKIN { get => Checkin; set => Checkin = value; }
        public DateTime CHECKOUT { get => Checkout; set => Checkout = value; }
        public long TOTAL { get => total; set => total = value; }
        public List<Orderinfo> Info { get => info; set => info = value; }
    }
}
