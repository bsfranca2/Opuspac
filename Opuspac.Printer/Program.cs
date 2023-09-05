using Newtonsoft.Json;
using System;
using System.CommandLine;
using System.IO;

namespace Opuspac.Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileArgument = new Argument<FileInfo>(name: "file", description: "Arquivo JSON da prescrição");
            var rootCommand = new RootCommand("Realizar impressoes")
            {
                fileArgument
            };
            rootCommand.SetHandler((file) =>
            {
                if (file == null)
                {
                    Console.WriteLine("File not provided");
                    return;
                }

                var json = File.ReadAllText(file.ToString());
                var printData = JsonConvert.DeserializeObject<PrintData>(json);
                using (var printer = new Printer())
                {
                    printer.Print(printData);
                }
            }, fileArgument);
            rootCommand.Invoke(args);
        }
    }
}
