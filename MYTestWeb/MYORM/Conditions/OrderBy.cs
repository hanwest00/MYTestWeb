using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class OrderBy : MYDBCondition
    {
        public OrderBy(string propName)
        {
            ConditionName = "order by";
            PropName = propName;
        }

        public override string ToQueryString()
        {
            return string.Format(" {0} {1} ", ConditionName, PropName);
        }
    }
}
