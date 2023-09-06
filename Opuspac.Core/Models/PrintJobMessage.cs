using Opuspac.Core.Entities;

namespace Opuspac.Core.Models;

public class PrintJobMessage
{
    public Guid PrintJobId { get; set; }

    public string PrescriptionCode { get; set; }

    public string PatientName { get; set; }

    public string PatientBed { get; set; }

    public string AttendantId { get; set; }

    public string Time { get; set; }

    public List<Medicine> Medicines { get; set; }

    public record Medicine(string Name, int Quantity, string AdministrationInstructions) {}
}

public static class PrescriptionMedicineExtension
{
    public static PrintJobMessage.Medicine ToPrintJobMessageMedicine(this PrescriptionMedicine prescriptionMedicine)
    {
        var model = new PrintJobMessage.Medicine(
            prescriptionMedicine.MedicineName,
            prescriptionMedicine.Quantity,
            prescriptionMedicine.AdministrationInstructions);
        return model;
    }
}
