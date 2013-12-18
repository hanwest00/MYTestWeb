using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public class GroupBy : MYDBCondition
    {
        public GroupBy(string propName)
        {
            ConditionName = "group by";
            PropName = propName;
        }

        public override string ToQueryString()
        {
            return string.Format(" {0} [{1}] ", ConditionName, PropName);
        }
    }
}
