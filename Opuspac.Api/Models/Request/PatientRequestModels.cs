using System.ComponentModel.DataAnnotations;
using Opuspac.Core.Entities;

namespace Opuspac.Api.Models.Request;

public class PatientRequestModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public Patient ToPatient()
    {
        return ToPatient(new Patient());
    }

    public Patient ToPatient(Patient existingPatient)
    {
        existingPatient.Name = Name;
        return existingPatient;
    }
}