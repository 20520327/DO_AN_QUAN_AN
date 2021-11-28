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
        protected int Employeeid;
        protected string userrole;

        public string USERNAME {
            get { return this.username; }
            set { this.username = value; }
        }
        public string PASSWORD { get => password; set => password = value; }
        public int EMPLOYEEID { get => Employeeid; set => Employeeid = value; }
        public string USERROLE { get => userrole; set => userrole = value; }
    }
}
