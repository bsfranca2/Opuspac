using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class PrinterAgent : ITableObject<Guid>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Ip { get; set; }
    
    public string PrinterModel { get; set; }
    
    public string? ClientId { get; set; }
    
    public bool IsConnected { get; set; }

    public DateTime? LastActiveConnectionDate { get; set; }
    
    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }

    public void Connect(string clientId)
    {
        ClientId = clientId;
        IsConnected = true;
        LastActiveConnectionDate = DateTime.Now;
    }

    public void Disconnect()
    {
        ClientId = null;
        IsConnected = false;
        LastActiveConnectionDate = DateTime.Now;
    }
}