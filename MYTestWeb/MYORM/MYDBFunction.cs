using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;

namespace MYORM
{
    public abstract class MYDBFunction : IToQueryable
    {
        private string funcName = string.Empty;

        public abstract string ToQueryString();
    }
}
