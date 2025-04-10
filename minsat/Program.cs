
using minsat;
using System.IO;
using System.Xml;
using Spectre.Console;
using minsat.Primitives;
using minsat.Countries;

public static class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            AnsiConsole.Write(
                new FigletText("Bienvenido a Minsat :)")
                .Color(Color.Red));
            var table = new Table();
            table.Title("Commands available");
            table.AddColumns("command","use","Options");
            table.AddRow("summarize", "used to summarize Reciepts in a directory", "[[PATH]]");
            AnsiConsole.Write(table);

        }
        else if (args[0]=="summarize")
        {
            if (args.Length<=2)  // summarize [PATH] ...
            {
                Mexico procesor = new(args.Length == 2 ? args[1] : Directory.GetCurrentDirectory());// either corrent directory or specified one
                procesor.process();
            }
            
        }
    }
}





