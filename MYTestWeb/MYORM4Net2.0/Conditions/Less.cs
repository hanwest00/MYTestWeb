using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public class Less : MYDBCondition
    {
        public Less(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "<";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
