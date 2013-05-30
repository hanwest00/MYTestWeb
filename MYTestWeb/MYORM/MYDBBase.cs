using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MYORM.Exceptions;

namespace MYORM
{
    public abstract class MYDBBase
    {
        
        public static string dbMasterConnectString;
        public MYDBEXE dbExe;

        public string DatabaseName
        {
            get;
            set;
        }

        public string DbFileDir
        {
            get;
            set;
        }

        protected abstract bool DBContians();

        protected abstract bool TableContians(Type table, out string tableName);

        protected abstract int CreateDatebase();

        public abstract int CreateTable(Type table);

        public abstract int DropTable(Type table);
    }
}
