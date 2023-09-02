using Opuspac.Core.Enums;
using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class PrintJob : ITableObject<Guid>
{
    public Guid Id { get; set; }
    
    public Guid PrescriptionId { get; set; }
    
    public string Ip { get; set; }
    
    public PrintJobStatus Status { get; set; }
    
    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}