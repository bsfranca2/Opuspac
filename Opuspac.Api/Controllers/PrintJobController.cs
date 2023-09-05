using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Opuspac.Api.Hubs;
using Opuspac.Core.Entities;
using Opuspac.Core.Models;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/print-jobs")]
public class PrintJobController : Controller
{
    private IHubContext<PrinterHub> _hub { get; set; }

    private readonly IPrintJobRepository _printJobRepository;

    private readonly IPrinterAgentRepository _printerAgentRepository;

    public PrintJobController(IHubContext<PrinterHub> hub, IPrintJobRepository printJobRepository, IPrinterAgentRepository printerAgentRepository)
    {
        _hub = hub;
        _printJobRepository = printJobRepository;
        _printerAgentRepository = printerAgentRepository;
    }

    [HttpPost]
    public async Task<IResult> Post()
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        if (ipAddress == null)
        {
            throw new BadHttpRequestException("Required request ip address");
        }

        var printJob = new PrintJob
        {
            Ip = ipAddress,
            PrescriptionId = Guid.NewGuid(), // TODO: Tem que vim do req body
            Status = Core.Enums.PrintJobStatus.Waiting
        };
        await _printJobRepository.CreateAsync(printJob);

        var printerAgent = await _printerAgentRepository.GetByIpAsync(ipAddress);
        if (printerAgent != null && printerAgent.ClientId != null)
        {
            var message = new PrintJobMessage
            {
                PrintJobId = printJob.Id
            };
            await _hub.Clients.Client(printerAgent.ClientId).SendAsync("Print", message);
        }

        return Results.Created($"/print-jobs/{printJob.Id}", printJob);
    }
}
