using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Orderinfo
    {
        private long OrderID;
        private int FOODid;
        private string FOODname;
        private int QUATITY;
        private int PRICE;
        private int TOTAL;

        public long OrderID1 { get => OrderID; set => OrderID = value; }
        public int FOODid1 { get => FOODid; set => FOODid = value; } 
        public int QUATITY1 { get => QUATITY; set => QUATITY = value; }
        public int TOTAL1 { get => TOTAL; set => TOTAL = value; }
        public string FOODname1 { get => FOODname; set => FOODname = value; }
        public int PRICE1 { get => PRICE; set => PRICE = value; }
    }
}
