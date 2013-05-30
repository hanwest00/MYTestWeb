using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;

namespace MYORM
{
    public class MYDBQJoin : IToQueryable
    {
        private JoinType Type;
        private MYDBCondition[] On;
        private string Table;
        public MYDBQJoin(string table, JoinType type,params MYDBCondition[] on)
        {
            Table = table;
            Type = type;
            On = on;
        }

        public enum JoinType
        {
            LEFT, RIGHT, INNER
        }

        public virtual string ToQueryString()
        { 
            StringBuilder sb = new StringBuilder();
            On.ToList().ForEach((s) => {
                if (s.Type > MYDBConditionType.NOTEQUAL)
                    return;
               sb.Append(s.ToQueryString());
            });
            return string.Format("{0} join {1} on {2}", Type.ToString(), Table, sb.ToString());
        }
    }
}
