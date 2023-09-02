using Microsoft.AspNetCore.SignalR.Client;
using Opuspac.Agent.Printer;
using Opuspac.Core.Models;

namespace Opuspac.Agent;

public  static class PrinterWorker {

    public static async Task Start(string serverUri)
    {
        var url = $"{serverUri}/printer";

        await using var connection = new HubConnectionBuilder()
            .WithUrl(url, options =>
            {
                options.Headers.Add("X-Agent-Name", Environment.MachineName);
                options.Headers.Add("X-Printer-Model", "EPSON TM-T20x");
            })
            .Build();

        connection.On<PrintJobMessage>("Print", async (message) =>
        {
            Console.WriteLine($"Executando tarefa de impressão: {message.PrintJobId}");
            var printer = new PrinterInMemory();
            var printJob = new PrintJob(printer, connection);
            await printJob.Perform(message.PrintJobId);
            Console.WriteLine($"Tarefa de impressão finalizada: {message.PrintJobId}");
        });

        try
        {
            Console.WriteLine($"Servidor: {url}");
            await connection.StartAsync();
        } catch
        {
            Console.WriteLine("Não foi possível se conectar ao servidor");
            return;
        }

        Console.ReadLine();
        await connection.DisposeAsync();
    }
}
