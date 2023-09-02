using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class PrescriptionMedicine : ITableObject<Guid>
{
    public Guid Id { get; set; }

    public Guid MedicineId { get; set; }
    
    public int Quantity { get; set; }
    
    public string AdministrationInstructions { get; set; }
    
    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}