using AutoMapper;

namespace Opuspac.Data.Models;

public class Patient : Core.Entities.Patient
{
}

public class PatientMapperProfile : Profile
{
    public PatientMapperProfile()
    {
        CreateMap<Core.Entities.Patient, Patient>().ReverseMap();
    }
}