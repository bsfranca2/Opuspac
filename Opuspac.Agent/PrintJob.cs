using Microsoft.AspNetCore.SignalR.Client;
using Opuspac.Agent.Printer;
using Opuspac.Core.Enums;

namespace Opuspac.Agent;

class PrintJob
{
    private readonly IPrinter _printer;

    private readonly HubConnection _connection;


    public PrintJob(IPrinter printer, HubConnection connection)
    {
        _printer = printer;
        _connection = connection;
    }

    public async Task Perform(Guid printJobId)
    {
        await _connection.SendAsync("UpdatePrintJobStatus", printJobId, PrintJobStatus.Running);
        var printSuccess = await _printer.Print();

        if (printSuccess == false)
        {
            await _connection.SendAsync("UpdatePrintJobStatus", printJobId, PrintJobStatus.Error);
            return;
        }

        await _connection.SendAsync("UpdatePrintJobStatus", printJobId, PrintJobStatus.Done);
    }
}
