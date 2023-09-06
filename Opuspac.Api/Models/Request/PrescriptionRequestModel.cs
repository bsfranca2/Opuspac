using Opuspac.Core.Entities;

namespace Opuspac.Api.Models.Request;

public class PrescriptionRequestModel
{
    public Guid PatientId { get; set; }

    public string Code { get; set; }

    public string AttendantId { get; set; }

    public string Time { get; set; }

    public List<PrescriptionMedicineRequestModel> Medicines { get; set; }

    public Prescription ToPrescription()
    {
        return new Prescription
        {
            PatientId = PatientId,
            Code = Code,
            AttendantId = AttendantId,
            Time = Time
        };
    }
}

public record PrescriptionMedicineRequestModel(string Name, int Quantity, string AdministrationInstructions)
{
    public PrescriptionMedicine ToPrescriptionMedicine(Guid prescriptionId)
    {
        return new PrescriptionMedicine
        {
            PrescriptionId = prescriptionId,
            MedicineName = Name,
            Quantity = Quantity,
            AdministrationInstructions = AdministrationInstructions,
        };
    }
}
