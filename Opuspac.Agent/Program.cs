using Microsoft.Extensions.Configuration;
using Opuspac.Agent;
using Opuspac.Agent.PrinterClient;
using System.CommandLine;

var configuration = new ConfigurationBuilder().AddJsonFile("serversettings.json", optional: false, reloadOnChange: true).Build();
var settings = new Settings(configuration);

var rootCommand = new RootCommand("Este programa conecta-se ao servidor e imprime documentos na impressora local a partir de instruções remotas.");


var connectToServerCommand = new Command("connect", "Estabelece conexão com o servidor.");
connectToServerCommand.SetHandler(async () =>
{
    var printerClient = new PrinterClient(settings);
    var printerWorker = new PrinterWorker(printerClient, settings);
    await printerWorker.Start();
});
rootCommand.AddCommand(connectToServerCommand);

var fileArgument = new Argument<FileInfo?>("file", "O arquivo JSON do print data.");
var printDataCommand = new Command("print-data", "Imprime uma página na impressora local.")
{
    fileArgument
};
printDataCommand.SetHandler((file) =>
{
    if (file == null)
    {
        throw new Exception("Arquivo não fornecido");
    }
    var printerClient = new PrinterClient(settings);
    printerClient.ExecuteProcess(file.ToString());
}, fileArgument);
rootCommand.AddCommand(printDataCommand);

await rootCommand.InvokeAsync(args);
