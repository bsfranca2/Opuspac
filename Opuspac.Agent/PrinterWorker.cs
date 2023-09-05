using Microsoft.AspNetCore.SignalR.Client;
using Opuspac.Agent.PrinterClient;
using Opuspac.Core.Enums;
using Opuspac.Core.Models;

namespace Opuspac.Agent;

public class PrinterWorker
{

    private readonly IPrinterClient _printerClient;
    private readonly ISettings _settings;

    public PrinterWorker(IPrinterClient printerClient, ISettings settings)
    {
        _printerClient = printerClient;
        _settings = settings;
    }

    public async Task Start()
    {
        var url = $"{_settings.ServerUrl}/printer";

        await using var connection = new HubConnectionBuilder()
            .WithUrl(url, options =>
            {
                options.Headers.Add("X-Agent-Name", Environment.MachineName);
                options.Headers.Add("X-Printer-Model", "EPSON TM-T20X");
            })
            .Build();

        connection.On<PrintJobMessage>("Print", async (message) =>
        {
            Console.WriteLine($"Executando tarefa de impressão: {message.PrintJobId}");

            await connection.SendAsync("UpdatePrintJobStatus", message.PrintJobId, PrintJobStatus.Running);
            var printSuccess = _printerClient.Print(message);

            if (printSuccess == false)
            {
                await connection.SendAsync("UpdatePrintJobStatus", message.PrintJobId, PrintJobStatus.Error);
            }
            else
            {
                await connection.SendAsync("UpdatePrintJobStatus", message.PrintJobId, PrintJobStatus.Done);

            }
            Console.WriteLine($"Tarefa de impressão finalizada: {message.PrintJobId}");
        });

        try
        {
            Console.WriteLine($"Servidor: {url}");
            await connection.StartAsync();
        }
        catch
        {
            Console.WriteLine("Não foi possível se conectar ao servidor");
            return;
        }

        Console.ReadLine();
        await connection.DisposeAsync();
    }
}
