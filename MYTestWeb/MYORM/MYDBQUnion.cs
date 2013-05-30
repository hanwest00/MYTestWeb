using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;

namespace MYORM
{
    public class MYDBQUnion : IToQueryable
    {
        public MYDBQUnion()
        { 
           
        }

        public virtual string ToQueryString()
        {
            return string.Empty;
        }
    }
}
