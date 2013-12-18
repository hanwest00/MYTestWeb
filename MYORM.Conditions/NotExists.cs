using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Conditions
{
    public class NotExists : MYDBCondition
    {
        public NotExists(MYDBLogic logic, string propName, params string[] values)
        {
            ConditionName = "not exists";
            Logic = logic;
            PropName = propName;
            Values = values;
        }
    }
}
