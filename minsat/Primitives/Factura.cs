using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minsat.Primitives
{
    class Factura
    {

        public double SubTotal = -1;
        public double Total = -1;
        public string concepto = null;
        public string fecha = null;
        public string CFDI = null;
        public string emisor = null;


        public string toString()
        {
            return $"|{concepto}|{fecha}|{SubTotal}|{Total}";
        }

        public void toTable(Table table)
        {
            table.AddRow(new string[]{ fecha, concepto, SubTotal.ToString(), Total.ToString()});
        }
        public void trim()
        {
            this.concepto=this.concepto.Trim(',');
        }
    }
    
}
