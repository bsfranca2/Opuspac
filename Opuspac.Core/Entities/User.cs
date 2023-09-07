using Opuspac.Core.Utilities;

namespace Opuspac.Core.Entities;

public class User : ITableObject<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }
}