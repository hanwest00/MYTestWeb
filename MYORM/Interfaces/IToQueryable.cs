using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Interfaces
{
    public interface IToQueryable
	{
        string ToQueryString();
	}
}
