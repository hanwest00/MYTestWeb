using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;

namespace MYORM
{
    public class MYDBQUnion : IToQueryable
    {
        private string tableName;
        public MYDBQUnion(string table,bool all)
        {
            tableName = table;
        }

        public virtual string ToQueryString()
        {
            return string.Format(" union {0} ",  tableName);
        }
    }
}
