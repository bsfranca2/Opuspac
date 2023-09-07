using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Models.Response;
using Opuspac.Core.Enums;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/printer-metrics")]
[Authorize]
public class PrintMetricsController : Controller
{
    private readonly IPrinterAgentRepository _printerAgentRepository;
    private readonly IPrintJobRepository _printJobRepository;

    public PrintMetricsController(IPrinterAgentRepository printerAgentRepository, IPrintJobRepository printJobRepository)
    {
        _printerAgentRepository = printerAgentRepository;
        _printJobRepository = printJobRepository;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        var printerAgentsConnected = await _printerAgentRepository.GetPrinterAgentsCountByIsConnected();
        var printJobsWaiting = await _printJobRepository.GetJobsCountByStatusAsync(PrintJobStatus.Waiting);
        var printJobsError = await _printJobRepository.GetJobsCountByStatusAsync(PrintJobStatus.Error);
        var metrics = new PrinterMetricsResponseModel(printerAgentsConnected, printJobsWaiting, printJobsError);
        return Results.Ok(metrics);
    }
}