namespace Opuspac.Agent.Printer;

public interface IPrinter
{
    public Task<bool> Print();
    // public Task PrintPrescription();
}