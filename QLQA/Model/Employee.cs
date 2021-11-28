using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Employee
    {
        private int id;
        public string name;
        public string position;
        public string sex;
        public string phone;
        public string address;
        public string email;

        public int EID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string ENAME
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string EPOSITION
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public string ESEX
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string EPHONE
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string EADDRESS
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string EEMAIL
        {
            get { return this.email; }
            set { this.email = value; }
        }
    }
}
