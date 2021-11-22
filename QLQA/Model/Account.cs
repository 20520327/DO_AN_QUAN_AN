using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    class Account
    {
        protected string username;
        protected string password;
        protected string name;
        protected bool userrole;

        public string Username {
            get { return this.username; }
            private set { this.username = value; }
        }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public bool Userrole { get => userrole; set => userrole = value; }
    }
}
