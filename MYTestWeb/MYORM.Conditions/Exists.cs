using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class Exists : MYDBCondition
    {
        public Exists(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "exists";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
