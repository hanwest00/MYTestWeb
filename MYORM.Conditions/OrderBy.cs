using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class OrderBy : MYDBCondition
    {
        public string Asc
        {
            get;
            set;
        }

        public OrderBy(string propName,string asc)
        {
            ConditionName = "order by";
            PropName = propName;
            Asc = asc;
        }

        public override string ToQueryString()
        {
            return string.Format(" {0} {1} {2}", ConditionName, PropName, Asc);
        }
    }
}
