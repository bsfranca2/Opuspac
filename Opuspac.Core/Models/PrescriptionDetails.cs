using Opuspac.Core.Entities;

namespace Opuspac.Core.Models;

public class PrescriptionDetails : Prescription
{
    public Patient Patient {  get; set; }

    //public List<PrescriptionMedicine> Medicines { get; set; }
}
