using Opuspac.Core.Models;

namespace Opuspac.Agent.PrinterClient;

class PrinterClientInMemory : IPrinterClient
{
    public bool Print(PrintJobMessage printJobMessage)
    {
        Console.WriteLine("Simulando a impressao...");
        Task.Delay(1000);
        return true;
    }
}
