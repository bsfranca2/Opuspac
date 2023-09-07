using Opuspac.Core.Entities;

namespace Opuspac.Core.Services;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
