﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.model
{
    internal class User
    {
        static int TotalLoggedInUsers = 0;
        int id;
        string name;
        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
            TotalLoggedInUsers++;
        }
        public int GetTotalLoggedInUsers()
        {
            return TotalLoggedInUsers;
        }
    }
}
