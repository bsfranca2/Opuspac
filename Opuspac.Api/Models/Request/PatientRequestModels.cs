using System.ComponentModel.DataAnnotations;
using Opuspac.Core.Entities;

namespace Opuspac.Api.Models.Request;

public class PatientRequestModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Bed { get; set; }

    public Patient ToPatient()
    {
        return ToPatient(new Patient());
    }

    public Patient ToPatient(Patient existingPatient)
    {
        existingPatient.Name = Name;
        existingPatient.Bed = Bed;
        return existingPatient;
    }
}