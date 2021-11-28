using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.Model
{
    public class Login
    {
        private int employeeid;
        private int roleid;
        private string username;
        private string password;

        public int EMPLOYEEid { get => employeeid; set => employeeid = value; }
        public int ROLEid { get => roleid; set => roleid = value; }
        public string USERNAME { get => username; set => username = value; }
        public string PASSWORD { get => password; set => password = value; }
    }
}
