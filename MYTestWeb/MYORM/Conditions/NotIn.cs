using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class NotIn : MYDBCondition
    {
        public NotIn(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "not in";
            Logic = logic;
            PropName = propName;
            Values = values;
        }

        public override string ToQueryString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            Values.ToList().ForEach((s) => { sb.Append(s); if (sb.Length != 1)sb.Append(","); });
            sb.Append(")");
            return string.Format(" {0} {1} {2} {3} ", (Logic != MYDBLogic.NOTSET ? Logic.ToString() : string.Empty), PropName, ConditionName, sb.ToString());
        }
    }
}
