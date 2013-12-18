using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Conditions
{
    public enum MYDBConditionType
    {
        EQUAL,
        NOTEQUAL,
        MORE,
        LESS,
        MOREEQUAL,
        LESSEQUAL,
        EXISTS,
        NOTIN,
        IN,
        NOTEXISTS,
        GROUPBY,
        ORDERBY,
        LIKE
    }
}
