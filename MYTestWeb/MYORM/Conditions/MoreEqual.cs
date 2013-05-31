using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class MoreEqual : MYDBCondition
    {
        public MoreEqual(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = ">=";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
