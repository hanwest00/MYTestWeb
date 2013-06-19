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
            ////test orm ok
            //Business.Users us = new Business.Users();
            //Data.Tables.User user = new Data.Tables.User { GroupId = 0, Name = "121" };
            //us.Insert(user);

            ////test ioc ok
            //MYIoc.IocContains contains = new MYIoc.IocContains();
            //contains.RegisterTypeFromConfig();
            //IIocTest test = contains.Resolve<IIocTest>();
            //bool b1 = test.TestConstrIoc();
            //bool b2 = test.TestParamIoc();
            //bool b3 = test.DoMethodIoc();
        }
    }
}
