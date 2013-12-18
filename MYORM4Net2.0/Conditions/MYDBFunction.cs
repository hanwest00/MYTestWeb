using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public abstract class MYDBFunction : Interfaces.IToQueryable
    {
        private string funcName = string.Empty;

        public abstract string ToQueryString();
    }
}
