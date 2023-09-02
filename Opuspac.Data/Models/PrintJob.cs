using AutoMapper;

namespace Opuspac.Data.Models;

public class PrintJob : Core.Entities.PrintJob
{
}

public class PrintJobMapperProfile : Profile
{
    public PrintJobMapperProfile()
    {
        CreateMap<Core.Entities.PrintJob, PrintJob>().ReverseMap();
    }
}