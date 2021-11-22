using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    class Food
    {
        private int id;
        public string name;
        public string category_name;
        public float price;
        public int ID
        {
            get { return this.id; }
            private set { this.id = value; }
        } 
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Category_name
        {
            get { return this.category_name; }
            set { this.category_name = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
