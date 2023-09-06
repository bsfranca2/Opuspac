using AutoMapper;

namespace Opuspac.Data.Models;

public class Prescription: Core.Entities.Prescription
{
}

public class PrescriptionMapperProfile : Profile
{
    public PrescriptionMapperProfile()
    {
        CreateMap<Core.Entities.Prescription, Prescription>().ReverseMap();
    }
}