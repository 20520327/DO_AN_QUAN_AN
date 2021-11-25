using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Table
    {
        private int id;
        public string name;
        public string status;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string NAME
        {
            get { return this.name;}
            set { this.name = value; }
        }
        
        public string STATUS
        {
            get { return this.status; }
            set { this.status = value; }
        } 
    }
}
