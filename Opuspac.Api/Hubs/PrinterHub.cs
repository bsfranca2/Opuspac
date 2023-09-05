using Microsoft.AspNetCore.SignalR;
using Opuspac.Core.Entities;
using Opuspac.Core.Enums;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Hubs;

public class PrinterHub : Hub
{
    private ILogger<PrinterHub> _logger;
    private readonly IPrinterAgentRepository _printerAgentRepository;
    private readonly IPrintJobRepository _printJobRepository;

    public PrinterHub(ILogger<PrinterHub> logger, IPrinterAgentRepository printerAgentRepository, IPrintJobRepository printJobRepository)
    {
        _logger = logger;
        _printerAgentRepository = printerAgentRepository;
        _printJobRepository = printJobRepository;
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

        // TODO: Talvez extrair para um service
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

        // TODO: Buscar por tarefas pendentes para esse ip

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
        var printJob = await _printJobRepository.GetByIdAsync(printJobId);
        if (printJob == null)
        {
            _logger.LogWarning($"Trabalho de impressão não encontrado: {printJobId}");
            return;
        }

        printJob.Status = printJobStatus;
        await _printJobRepository.ReplaceAsync(printJob);
    }
}