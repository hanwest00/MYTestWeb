using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public abstract class MYDBFunction : IToQueryable
    {
        private string funcName = string.Empty;

        public abstract string ToQueryString();
    }
}
