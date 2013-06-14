using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Business.Users us = new Business.Users();
            Data.Tables.User user = new Data.Tables.User { GroupId = 0, Name = "121" };
            us.Insert(user);
        }
    }
}
