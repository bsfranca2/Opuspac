using Opuspac.Core.Models;

namespace Opuspac.Agent.PrinterClient;

public interface IPrinterClient
{
    public bool Print(PrintJobMessage printJobMessage);
}
