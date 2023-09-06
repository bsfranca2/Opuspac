using System.ComponentModel.DataAnnotations;

namespace Opuspac.Api.Models.Request;

public class PrintJobRequestModel
{
    [Required]
    public Guid PrescriptionId {  get; set; }
}
