using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Opuspac.Api.Hubs;
using Opuspac.Api.Models.Request;
using Opuspac.Core.Repositories;
using Opuspac.Core.Services;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/print-jobs")]
public class PrintJobController : Controller
{
    private IHubContext<PrinterHub> _hub { get; set; }
    private readonly IPrinterAgentRepository _printerAgentRepository;
    private readonly IPrintJobService _printJobService;

    public PrintJobController(
        IHubContext<PrinterHub> hub,
        IPrinterAgentRepository printerAgentRepository,
        IPrintJobService printJobService)
    {
        _hub = hub;
        _printerAgentRepository = printerAgentRepository;
        _printJobService = printJobService;
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] PrintJobRequestModel printJobRequestModel)
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString().Replace("::ffff:", "");
        if (ipAddress == null)
        {
            throw new BadHttpRequestException("Required request ip address");
        }

        var printJob = await _printJobService.CreateAsync(printJobRequestModel.PrescriptionId, ipAddress);

        var printerAgent = await _printerAgentRepository.GetByIpAsync(ipAddress);
        if (printerAgent != null && printerAgent.ClientId != null)
        {
            var message = await _printJobService.GetPrintJobMessageAsync(printJob.Id);
            await _hub.Clients.Client(printerAgent.ClientId).SendAsync("Print", message);
        }

        return Results.Created($"/print-jobs/{printJob.Id}", printJob);
    }
}
