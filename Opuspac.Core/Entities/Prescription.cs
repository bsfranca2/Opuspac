using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class Prescription : ITableObject<Guid>
{
    public Guid Id { get; set; }
    
    public Guid PatientId { get; set; }
    
    public int TreatmentNumber { get; set; }
    
    /// TODO: Adicionar horario
    
    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}
