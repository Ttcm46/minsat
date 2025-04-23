using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minsat.Primitives
{
    internal class Flag
    {
        public bool isActive = false;
        public string value = null;

        public Flag() { }
        public Flag(string value)
        {
            this.value = value;
        }
    }
}
