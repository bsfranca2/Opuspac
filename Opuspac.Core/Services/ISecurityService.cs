using Opuspac.Core.Entities;

namespace Opuspac.Core.Services;

public interface ISecurityService
{
    Task<bool> VerifyPassword(string password, User user);
    Task<string> EncryptPassword(string password);
}
