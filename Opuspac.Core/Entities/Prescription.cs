using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class Prescription : ITableObject<Guid>
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public Guid PatientId { get; set; }

    public string AttendantId { get; set; }

    // TODO: Trocar para TimeOnly?
    public string Time { get; set; }

    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}
