using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYIoc.Config
{
    public class method : INode
    {
        public string Name
        {
            get;
            set;
        }

        private IDictionary<int, param> parameters;

        public param this[int index]
        {
            get
            {
                return parameters[index];
            }
            set
            {
                parameters[index] = value;
            }
        }

        public method()
        {
            parameters = new Dictionary<int, param>();
        }

        public void Add(param item)
        {
            parameters.Add(parameters.Count, item);
        }

        public void Remove(int index)
        {
            parameters.Remove(index);
        }

        public void Remove(param item)
        {
            parameters.Remove(parameters.Where(w => w.Value == item).First().Key);
        }
    }
}
