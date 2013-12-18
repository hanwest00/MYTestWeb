using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYIoc.Config
{
    public interface INode
    {
        void Add(param item);

        void Remove(int index);

        void Remove(param item);
    }
}
