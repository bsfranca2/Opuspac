using AutoMapper;

namespace Opuspac.Data.Models;

public class PrinterAgent : Core.Entities.PrinterAgent
{
}

public class PrinterAgentMapperProfile : Profile
{
    public PrinterAgentMapperProfile()
    {
        CreateMap<Core.Entities.PrinterAgent, PrinterAgent>().ReverseMap();
    }
}