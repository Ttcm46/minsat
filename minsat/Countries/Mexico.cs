using minsat.Primitives;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace minsat.Countries
{
    class Mexico
    {
        public string PATH;

        private Facturas facturas;
        private double subtotal;
        private double total;
        private int number_of_reciepts;

        public Mexico(string pATH)
        {
            this.PATH = pATH;
            this.facturas = new Facturas();
            this.subtotal = 0;
            this.total = 0;
            this.number_of_reciepts = 0;
        }

        public void process()
        {
            DirectoryInfo d = new DirectoryInfo(this.PATH);
            FileInfo[] Files = d.GetFiles("*.xml"); //Getting Text files
            this.number_of_reciepts = Files.Length; //Total of reciepts found in directory

            XmlDocument doc = new XmlDocument();

            for (int i = 0; i < Files.Length; i++)
            {
                FileInfo f = Files[i];
                doc.Load(f.DirectoryName + '/' + f.Name);
                doc.Load(f.DirectoryName + '/' + f.Name);
                int node_num = 0;
                XmlNode node = doc.ChildNodes[node_num];           // second child
                while (node.Name != "cfdi:Comprobante")
                {
                    node_num += 1;
                    node = doc.ChildNodes[node_num];

                }


                Factura elem = new Factura();
                elem.SubTotal = double.Parse(node.Attributes["SubTotal"]?.InnerText);
                elem.Total = double.Parse(node.Attributes["Total"]?.InnerText);
                elem.fecha = node.Attributes["Fecha"]?.InnerText;
                int x = 0;
                while (doc.ChildNodes[node_num].ChildNodes[x].Name != "cfdi:Conceptos")
                {
                    x += 1;
                    node = doc.ChildNodes[node_num].ChildNodes[x];
                }
                node = doc.ChildNodes[node_num].ChildNodes[x].ChildNodes[0];
                elem.concepto = node.Attributes["Descripcion"]?.InnerText;

                this.subtotal += elem.SubTotal;
                this.total += elem.Total;
                this.facturas.List_Facturas.Add(elem);
            }
            AnsiConsole.Write(new Markup($"Found [underline green] {this.number_of_reciepts} [/] recipts in the directory"));
        }


    }
}
