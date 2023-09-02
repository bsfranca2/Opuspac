namespace Opuspac.Agent.Printer;

class PrinterInMemory : IPrinter
{
    public async Task<bool> Print()
    {
        Console.WriteLine("Simulando a impressao...");
        await Task.Delay(1000);
        return true;
    }
}
