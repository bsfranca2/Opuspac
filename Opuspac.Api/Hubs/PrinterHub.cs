using Microsoft.AspNetCore.SignalR;
using Opuspac.Core.Entities;
using Opuspac.Core.Enums;
using Opuspac.Core.Repositories;
using Opuspac.Core.Services;

namespace Opuspac.Api.Hubs;

public class PrinterHub : Hub
{
    private ILogger<PrinterHub> _logger;
    private readonly IPrinterAgentRepository _printerAgentRepository;
    private readonly IPrintJobService _printJobService;

    public PrinterHub(ILogger<PrinterHub> logger, IPrinterAgentRepository printerAgentRepository, IPrintJobService printJobService)
    {
        _logger = logger;
        _printerAgentRepository = printerAgentRepository;
        _printJobService = printJobService;
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        if (httpContext == null)
        {
            throw new HubException("Conexão mal formatada.");
        }

        var clientIpAddress = httpContext.Connection.RemoteIpAddress?.ToString().Replace("::ffff:", "");
        if (clientIpAddress == null)
        {
            throw new HubException("Necessário uma conexão com o IP fornecido.");
        }

        var printerAgent = await _printerAgentRepository.GetByIpAsync(clientIpAddress);
        if (printerAgent == null)
        {
            printerAgent = new PrinterAgent();
            printerAgent.Ip = clientIpAddress;
            if (httpContext.Request.Headers.ContainsKey("X-Agent-Name"))
            {
                printerAgent.Name = httpContext.Request.Headers["X-Agent-Name"]!;
            }
            if (httpContext.Request.Headers.ContainsKey("X-Printer-Model"))
            {
                printerAgent.PrinterModel = httpContext.Request.Headers["X-Printer-Model"]!;
            }
        }
        printerAgent.Connect(Context.ConnectionId);
        await _printerAgentRepository.UpsertAsync(printerAgent);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var clientIpAddress = Context.GetHttpContext()?.Connection.RemoteIpAddress?.ToString().Replace("::ffff:", "");
        if (clientIpAddress != null)
        {
            var printerAgent = await _printerAgentRepository.GetByIpAsync(clientIpAddress);
            if (printerAgent != null)
            {
                printerAgent.Disconnect();
                await _printerAgentRepository.ReplaceAsync(printerAgent);
            }
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task UpdatePrintJobStatus(Guid printJobId, PrintJobStatus printJobStatus)
    {
        try
        {
            await _printJobService.UpdatePrintJobStatusAsync(printJobId, printJobStatus);
        } catch
        {
            _logger.LogWarning($"Trabalho de impressão não encontrado: {printJobId}");
        }
    }
}