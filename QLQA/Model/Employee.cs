﻿using System;
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

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

    }
}
