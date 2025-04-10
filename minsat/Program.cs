
using minsat;
using System.IO;
using System.Xml;
using Spectre.Console;
using minsat.Primitives;

public static class Program
{
    static void Main(string[] args)
    {
        // Handle command-line arguments here


        //AnsiConsole.Markup(args[0]+"\n");
        //AnsiConsole.Markup(Directory.GetCurrentDirectory()+"\n");
        //if no directory is specified, choosew whatever directory the console is on
        DirectoryInfo d = new DirectoryInfo(args.Length==0 ? Directory.GetCurrentDirectory() : args[0]);
        FileInfo[] Files = d.GetFiles(); //Getting Text files
        XmlDocument doc = new XmlDocument();

        double total_ant_imps = 0;
        double total = 0;
        Facturas Elementos = new Facturas();
        for (int i = 0; i < Files.Length; i++)
        {

            FileInfo f = Files[i];
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

            total_ant_imps += elem.SubTotal;
            total += elem.Total;
            Elementos.List_Facturas.Add(elem);
        }

        Console.WriteLine("Subtotales: " + total_ant_imps);
        Console.WriteLine("Totales: " + total);

        Elementos.toTable();
    }
}





