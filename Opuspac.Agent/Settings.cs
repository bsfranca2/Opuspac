using Microsoft.Extensions.Configuration;

namespace Opuspac.Agent;

public class Settings : ISettings
{
    public string PrinterCliPath { get; set; }

    public string ServerUrl { get; set; }

    public Settings(IConfiguration configuration)
    {
        var printerCli = configuration["PrinterCli"];
        var serverUrl = configuration["ServerUrl"];
        if (printerCli != null && serverUrl != null)
        {
            PrinterCliPath = printerCli;
            ServerUrl = serverUrl;
        } else
        {
            throw new Exception("Necessário configurar o arquivo serversettings.json.");
        }
    }
}

public interface ISettings
{
    public string PrinterCliPath { get; set; }
    public string ServerUrl { get; set; }
}
