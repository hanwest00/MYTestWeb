using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public class Equal : MYDBCondition
    {
        public Equal(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "=";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
