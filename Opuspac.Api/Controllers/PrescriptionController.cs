using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Models.Request;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/prescriptions")]
[Authorize]
public class PrescriptionController : Controller
{
    private IPrescriptionRepository _prescriptionRepository { get; set; }
    private IPrescriptionMedicineRepository _prescriptionMedicineRepository { get; set; }

    public PrescriptionController(
        IPrescriptionRepository prescriptionRepository,
        IPrescriptionMedicineRepository prescriptionMedicineRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _prescriptionMedicineRepository = prescriptionMedicineRepository;
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] PrescriptionRequestModel prescriptionRequestModel)
    {
        var prescription = prescriptionRequestModel.ToPrescription();
        await _prescriptionRepository.CreateAsync(prescription);
        var prescriptionMedicines = prescriptionRequestModel.Medicines.Select(p => p.ToPrescriptionMedicine(prescription.Id)).ToList();
        foreach (var prescriptionMedicine in prescriptionMedicines)
        {
            await _prescriptionMedicineRepository.CreateAsync(prescriptionMedicine);
        }
        return Results.Ok(prescription);
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        var prescriptions = await _prescriptionRepository.SearchAsync();
        return Results.Ok(prescriptions);
    }
}
