using Opuspac.Core.Entities;

namespace Opuspac.Core.Services.Implementations;

public class SecurityService : ISecurityService
{
    public Task<string> EncryptPassword(string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return Task.FromResult(passwordHash);
    }

    public Task<bool> VerifyPassword(string password, User user)
    {
        var validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
        return Task.FromResult(validPassword);
    }
}
