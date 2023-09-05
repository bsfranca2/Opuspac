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

    public class Medicine
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string AdministrationInstructions { get; set; }
    }
}
