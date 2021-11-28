using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Food
    {
        private int id;
        public string name;
        public string category_name;
        public float price;
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
        public string CATEGORY_NAME
        {
            get { return this.category_name; }
            set { this.category_name = value; }
        }
        public float PRICE
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
