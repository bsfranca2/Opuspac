using Opuspac.Core.Entities;
using Opuspac.Core.Enums;
using Opuspac.Core.Models;
using Opuspac.Core.Repositories;

namespace Opuspac.Core.Services.Implementations;

public class PrintJobService : IPrintJobService
{
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionMedicineRepository _prescriptionMedicineRepository;
    private readonly IPatientRepository _patientRepository;

    public PrintJobService(
        IPrintJobRepository printJobRepository,
        IPrescriptionRepository prescriptionRepository,
        IPrescriptionMedicineRepository prescriptionMedicineRepository,
        IPatientRepository patientRepository)
    {
        _printJobRepository = printJobRepository;
        _prescriptionRepository = prescriptionRepository;
        _prescriptionMedicineRepository = prescriptionMedicineRepository;
        _patientRepository = patientRepository;
    }

    public async Task<PrintJob> CreateAsync(Guid prescriptionid, string ipAddress)
    {
        var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionid);
        if (prescription == null)
        {
            throw new Exception("Prescription not found");
        }
        var printJob = new PrintJob
        {
            Ip = ipAddress,
            PrescriptionId = prescriptionid,
            Status = PrintJobStatus.Waiting
        };
        await _printJobRepository.CreateAsync(printJob);
        return printJob;
    }

    public async Task<PrintJobMessage> GetPrintJobMessageAsync(Guid printJobId)
    {
        var printJob = await _printJobRepository.GetByIdAsync(printJobId);
        var prescription = await _prescriptionRepository.GetByIdAsync(printJob.PrescriptionId);
        var medicines = await _prescriptionMedicineRepository.GetManyByPrescriptionIdAsync(prescription.Id);
        var patient = await _patientRepository.GetByIdAsync(prescription.PatientId);
        var message = new PrintJobMessage
        {
            PrintJobId = printJob.Id,
            PatientName = patient.Name,
            PatientBed = patient.Bed,
            PrescriptionCode = prescription.Code,
            AttendantId = prescription.AttendantId,
            Time = prescription.Time,
            Medicines = medicines.Select(medicine => medicine.ToPrintJobMessageMedicine()).ToList()
        };
        return message;
    }

    public async Task<PrintJob> UpdatePrintJobStatusAsync(PrintJob job, PrintJobStatus status)
    {
        job.Status = status;
        await _printJobRepository.ReplaceAsync(job);
        return job;
    }

    public async Task<PrintJob> UpdatePrintJobStatusAsync(Guid id, PrintJobStatus status)
    {
        var printJob = await _printJobRepository.GetByIdAsync(id);
        if (printJob == null)
        {
            throw new Exception("Print job not found");
        }

        return await UpdatePrintJobStatusAsync(printJob, status);
    }
}
