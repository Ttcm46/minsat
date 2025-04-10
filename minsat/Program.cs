
using minsat;
using System.IO;
using System.Xml;
using Spectre.Console;

public static class Program
{
    static void Main(string[] args)
    {
        // Handle command-line arguments here


        AnsiConsole.Markup("[underline red]Welcome to Minisat[/] ");
        //if no directory is specified, choosew whatever directory the console is on
        DirectoryInfo d = new DirectoryInfo(args[0] == null ? "./" : args[0]);
        FileInfo[] Files = d.GetFiles(); //Getting Text files
        XmlDocument doc = new XmlDocument();

        double total_ant_imps = 0;
        double total = 0;
        List<Factura> Elementos = new List<Factura>();
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
            int x = 1;
            while (doc.ChildNodes[node_num].ChildNodes[x].Name != "cfdi:Conceptos")
            {
                x += 1;
                node = doc.ChildNodes[node_num].ChildNodes[x];
            }

            elem.concepto = node.Attributes["Descripcion"]?.InnerText;

            total_ant_imps += elem.SubTotal;
            total += elem.Total;
            Elementos.Add(elem);
        }

        Console.WriteLine("Subtotales: " + total_ant_imps);
        Console.WriteLine("Totales: " + total);
        Console.WriteLine(Elementos.ToString());

    }
}





