using Opuspac.Core.Models;
using System.Text.Json;

namespace Opuspac.Agent.PrinterClient;

class PrinterClientInMemory : IPrinterClient
{
    public bool Print(PrintJobMessage printJobMessage)
    {
        Console.WriteLine("Simulando a impressao...");
        var json = JsonSerializer.Serialize(printJobMessage);
        Console.WriteLine(json);
        Task.Delay(1000);
        return true;
    }
}
