using Opuspac.Core.Entities;

namespace Opuspac.Core.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    public Task<User> GetByEmailAsync(string email);
}
