using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class More : MYDBCondition
    {
        public More(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = ">";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
