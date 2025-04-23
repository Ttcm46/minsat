using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;

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

        public string Serialize_json()
        {

            if (List_Facturas == null)
            {
                return null;
            }
            return JsonSerializer.Serialize(List_Facturas);
        }

        //exportar a csv

        private void CreateHeader<T>(List<T> list, StreamWriter sw)
        {
            string[] properties = {"Fecha","Emisor","Concepto", "SubTotal","Total" };
            for (int i = 0; i < properties.Length; i++)
            {
                sw.Write(properties[i] + ",");
            }
            sw.Write(sw.NewLine);
        }

        private void CreateRows(StreamWriter sw)
        {
            foreach (var item in List_Facturas)
            {
                item.trim();
                sw.Write(item.fecha + "," + item.emisor + "," + item.concepto + "," + item.SubTotal + "," + item.Total + sw.NewLine);
            }
        }
        public void CreateCSV(string filePath)
        {
            filePath = filePath + "/exported_reciepts.csv";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                CreateHeader(this.List_Facturas, sw);
                CreateRows(sw);
            }
        }
    }


}
