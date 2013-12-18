using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public abstract class MYDBCondition : Interfaces.IToQueryable
    {
        protected string ConditionName;

        public MYDBLogic Logic
        {
            get;
            set;
        }

        public string PropName
        {
            get;
            set;
        }

        public string[] Values
        {
            get;
            set;
        }

        public virtual string ToQueryString()
        {
            return string.Format(" {0} [{1}] {2} {3} ", Logic.ToString(), PropName, ConditionName, Values[0]);
        }
    }
}
