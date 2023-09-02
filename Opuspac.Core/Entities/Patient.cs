using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class Patient : ITableObject<Guid>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Bed { get; set; }
    
    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}