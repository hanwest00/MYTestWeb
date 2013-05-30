using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;

namespace MYORM
{
    public class MYDBCondition : IToQueryable
    {
        public MYDBConditionType Type;
        private MYDBLogic Logic;
        private string Prop;
        private string[] Values;

        public MYDBCondition(MYDBConditionType type, MYDBLogic logic, string prop, params string[] values)
        {
            Type = type;
            Logic = logic;
            Prop = prop;
            Values = values;
        }

        public virtual string ToQueryString()
        {
            List<MYDBCondition> ss = new List<MYDBCondition>();
            StringBuilder sb = new StringBuilder();
            
            switch (Type)
            {
                case MYDBConditionType.IN:
                case MYDBConditionType.NOTIN:
                    sb.Clear();
                    sb.Append("(");
                    Values.ToList().ForEach((s) => { sb.Append(s); if (sb.Length != 1)sb.Append(","); });
                    sb.Append(")");
                    return string.Format(" {0} {1} {2} {3} ", (Logic != MYDBLogic.NOTSET ? Logic.ToString() : string.Empty), Prop, GetConditionString(Type), sb.ToString());
                case MYDBConditionType.GROUPBY:
                case MYDBConditionType.ORDERBY:
                    return string.Format(" {0} {1} ", GetConditionString(Type), Prop);
                default:
                    return string.Format(" {0} {1} {2} {3} ", (Logic != MYDBLogic.NOTSET ? Logic.ToString() : string.Empty), Prop, Type.ToString(), Values[0]);
            }
        }

        public static string GetConditionString(MYDBConditionType type)
        {
            switch (type)
            {
                case MYDBConditionType.EQUAL:
                    return "=";
                case MYDBConditionType.LESS:
                    return "<";
                case MYDBConditionType.MOREEQUAL:
                    return ">=";
                case MYDBConditionType.LESSEQUAL:
                    return "<=";
                case MYDBConditionType.NOTEQUAL:
                    return "!=";
                default:
                    return type.ToString();
            }
        }
    }
}
