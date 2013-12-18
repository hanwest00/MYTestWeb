using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM
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
