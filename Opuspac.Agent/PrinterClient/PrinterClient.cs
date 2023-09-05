using Opuspac.Core.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Opuspac.Agent.PrinterClient;

internal class PrinterClient : IPrinterClient
{
    private ISettings _settings { get; set; }

    public PrinterClient(ISettings settings)
    {
        _settings = settings;
    }

    public bool Print(PrintJobMessage printJobMessage)
    {
        var json = JsonSerializer.Serialize(printJobMessage);
        var tempJsonFilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        File.WriteAllText(tempJsonFilename, json);
        return ExecuteProcess(tempJsonFilename);
    }

    public bool ExecuteProcess(string printDataPath)
    {
        using var process = new Process();
        process.StartInfo.FileName = _settings.PrinterCliPath;
        process.StartInfo.Arguments = printDataPath;

        process.Start();

        process.WaitForExit();

        Console.WriteLine("O executável da impressora foi concluído.");
        return true;
    }
}
