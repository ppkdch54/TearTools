using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TearTools
{
    class ComboboxItem
    {
        public ComboboxItem(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public int Value { get; private set; }
    }
}
