using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minsat.Primitives
{
    class Facturas
    {
        public List<Factura> List_Facturas = new List<Factura>();

        public void toTable()
        {
            var table = new Table();

            // Add some columns
            table.AddColumn("Fecha");
            table.AddColumn("Concepto");
            table.AddColumn("Subtotal");
            table.AddColumn("Total");

            foreach (Factura elem in List_Facturas)
            {

                elem.toTable(table);
            }
            AnsiConsole.Write(table);


        }
    }


}
