using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minsat
{
    class Factura
    {

        public double SubTotal = -1;
        public double Total = -1;
        public string concepto = null;
        public string fecha = null;


        public string toString()
        {
            return $"|{concepto}|{fecha}|{SubTotal}|{Total}";
        }
    }
}
