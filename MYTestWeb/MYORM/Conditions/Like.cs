using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class Like : MYDBCondition
    {
        public Like(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "like";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
