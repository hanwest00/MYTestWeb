using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class Between : MYDBCondition
    {
        public Between(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "Between";
            Logic = logic;
            PropName = propName;
            Values = values;
        }

        public override string ToQueryString()
        {
            if (this.Values.Length < 2) return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(Values[0]);
            sb.Append(" and ");
            sb.Append(Values[1]);
            return string.Format(" {0} [{1}] {2} {3} ", Logic.ToString(), PropName, ConditionName, sb.ToString());
        }
    }
}
