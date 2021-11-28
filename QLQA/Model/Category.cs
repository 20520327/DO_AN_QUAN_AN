using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Category
    {
        public int id;
        public string name;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string NAME
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
