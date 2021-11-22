using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    class Table
    {
        private int id;
        public string name;
        public bool status;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
    }
}
