using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/printer-agents")]
[Authorize]
public class PrinterAgentController : Controller
{
    private readonly IPrinterAgentRepository _printerAgentRepository;

    public PrinterAgentController(IPrinterAgentRepository printerAgentRepository)
    {
        _printerAgentRepository = printerAgentRepository;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        var printerAgents = await _printerAgentRepository.SearchAsync();
        return Results.Ok(printerAgents);
    }
}