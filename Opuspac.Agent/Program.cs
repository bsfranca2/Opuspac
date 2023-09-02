using Opuspac.Agent;
using Opuspac.Agent.Printer;
using System.CommandLine;

var rootCommand = new RootCommand("Este programa conecta-se ao servidor e imprime documentos na impressora local a partir de instruções remotas.");

var printTestPage = new Command("print-test", "Imprime uma página de teste na impressora local.");
printTestPage.SetHandler(async () =>
{
    try
    {
        var printer = new PrinterInMemory();
        await printer.Print();
    }
    catch
    {
        Console.WriteLine("Falha ao imprimir");
    }
});
rootCommand.AddCommand(printTestPage);

var serverUriArgument = new Argument<string>(
    name: "serverUri",
    description: null,
    getDefaultValue: () => "http://localhost:5091");
var connectToServerCommand = new Command("connect", "Estabelece conexão com o servidor.")
{
    serverUriArgument
};
connectToServerCommand.SetHandler(PrinterWorker.Start, serverUriArgument);
rootCommand.AddCommand(connectToServerCommand);

await rootCommand.InvokeAsync(args);
