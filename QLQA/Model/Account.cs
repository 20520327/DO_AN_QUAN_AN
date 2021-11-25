using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Account
    {
        protected string username;
        protected string password;
        protected string name;
        protected int Employeeid;
        protected int userrole;

        public string Username {
            get { return this.username; }
            private set { this.username = value; }
        }
        public string PASSWORD { get => password; set => password = value; }
        public string NAME { get => name; set => name = value; }
        public int EMPLOYEEID { get => Employeeid; set => Employeeid = value; }
        public int Userrole { get => userrole; set => userrole = value; }
    }
}
