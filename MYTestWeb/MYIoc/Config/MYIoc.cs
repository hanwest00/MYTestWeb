using System.Linq;
using System.Collections.Generic;

namespace MYIoc.Config
{
    public sealed class MYIoc
    {
        private IDictionary<int, register> registers;

        public register this[int index]
        {
            get
            {
                return registers[index];
            }
            set
            {
                registers[index] = value;
            }
        }

        public MYIoc()
        {
            registers = new Dictionary<int, register>();
        }

        public void Add(register item)
        {
            registers.Add(registers.Count, item);
        }

        public void Remove(int index)
        {
            registers.Remove(index);
        }

        public void Remove(register item)
        {
            registers.Remove(registers.Where(w => w.Value == item).First().Key);
        }
    }
}
