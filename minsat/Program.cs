
using minsat;
using System.IO;
using System.Xml;
using Spectre.Console;
using minsat.Primitives;
using minsat.Countries;
using System.Globalization;

public static class Program

{
    private static Dictionary<string, Flag>? flags;
    static void Main(string[] args)
    {

        startflags();   //program startup
        CommandlineParser(args); //to proccess the request

        if (args.Length == 0)
        {
            AnsiConsole.Write(
                new FigletText("Bienvenido a Minsat :)")
                .Color(Color.Red));
            var table = new Table();
            table.Title("Commands available");
            table.AddColumns("command","use","Options");
            table.AddRow("summarize [options] [Flag] [options] ...", "used to summarize Reciepts in a directory", "[[PATH]]");
            AnsiConsole.Write(table);

        }
        else
        {
            //summarize
            //          PATH
            //              -e        
            //
            //
            //
            //
            //
            //
            Mexico procesor;

            if (flags["summarize"].isActive)
            {   
                procesor = new(flags["summarize"].value);// either current directory or specified one
                procesor.process();

                if (flags["-e"].isActive)
                {
                    procesor.ExportTo(flags["-e"].value,
                                        flags["-e/path"].isActive? flags["-e/path"].value: flags["summarize"].value   //specified ppath or the ccurrent one if not given
                                        );
                }
                else
                {
                    procesor.show();

                }
                    
            }
        }
    }

    private static void startflags()    //flag analisis, here we have all available options and is they where requested or not
    {
        flags = new Dictionary<string, Flag>();
        flags.Add("summarize", new Flag());
        flags.Add("-e",new Flag("csv"));
        flags.Add("-e/path", new Flag()); 
    }

    public static void CommandlineParser(string[] arguments)    //to make an analisis of what is requested
    {
        for (int i = 0; i < arguments.Length; i++)
        {
            var arg = arguments[i];
            switch (arg)
            {
                case "summarize":   //summarize

                    flags["summarize"].isActive = true;
                    //el sig no es flag
                    if ((i + 1) <= (arguments.Length - 1) && StringInfo.GetNextTextElement(arguments[i+1],0)!="-")
                    {
                        flags["summarize"].value=arguments[i+1];
                        i++;    // we skip the next since we know it isnt a flag
                    }
                    else
                        flags["summarize"].value = Directory.GetCurrentDirectory();                 
                    break;

                case "-e":          //exportar
                    //TODO: conflict here when not specifying file type but specifying path
                    flags["-e"].isActive = true;
                    if ((i + 1) <= (arguments.Length - 1) && StringInfo.GetNextTextElement(arguments[i + 1], 0) != "-")
                    {
                        flags["-e"].value = arguments[i + 1];
                        i++;    // we skip the next since we know it isnt a flag
                        
                    }

                    if ((i + 2) <= (arguments.Length - 1) && StringInfo.GetNextTextElement(arguments[i + 2], 0) != "-")
                    {
                        flags["-e/path"].isActive = true;
                        flags["-e/path"].value = arguments[i+2];
                        i++;
                    }

                    break;

            }

        }
    }
}





