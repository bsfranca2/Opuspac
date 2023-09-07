using Opuspac.Core.Entities;

namespace Opuspac.Core.Services;

public interface IUserService
{
    public Task<User> RegisterUserAsync(User user);

    public Task<string> GenerateSignInTokenAsync(string email, string password);
}
