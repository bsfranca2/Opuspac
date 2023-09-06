using AutoMapper;

namespace Opuspac.Data.Models;

public class PrescriptionMedicine : Core.Entities.PrescriptionMedicine
{
}

public class PrescriptionMedicineMapperProfile : Profile
{
    public PrescriptionMedicineMapperProfile()
    {
        CreateMap<Core.Entities.PrescriptionMedicine, PrescriptionMedicine>().ReverseMap();
    }
}