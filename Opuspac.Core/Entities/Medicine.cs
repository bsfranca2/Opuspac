using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class Medicine : ITableObject<Guid>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}