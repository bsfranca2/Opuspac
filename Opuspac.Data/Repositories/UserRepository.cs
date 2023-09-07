using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class UserRepository : Repository<Core.Entities.User, User, Guid>, IUserRepository
{
    public UserRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.Users) { }

    public async Task<Core.Entities.User> GetByEmailAsync(string email)
    {
        using var scope = ServiceScopeFactory.CreateScope();
        var dbContext = GetDatabaseContext(scope);
        var user = await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        return Mapper.Map<Core.Entities.User>(user);
    }
}
