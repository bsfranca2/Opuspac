using Opuspac.Core.Entities;
using Opuspac.Core.Exceptions;
using Opuspac.Core.Repositories;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Opuspac.Core.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ISecurityService _securityService;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, ISecurityService securityService, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _tokenService = tokenService;
    }

    public async Task<User> RegisterUserAsync(User user)
    {
        var isValidEmail = IsValidEmail(user.Email);
        if (isValidEmail == false)
        {
            throw new BadRequestException("Email mal formatado");
        }

        var userExists = await _userRepository.GetByEmailAsync(user.Email);
        if (userExists != null)
        {
            throw new BadRequestException("Email em uso");
        }

        user.Password = await _securityService.EncryptPassword(user.Password);

        await _userRepository.CreateAsync(user);
        return user;
    }

    private static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email);
    }

    public async Task<string> GenerateSignInTokenAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            await Task.Delay(1000);
            throw new BadRequestException("Credenciais inválidas");
        }

        var isSamePassword = await _securityService.VerifyPassword(password, user);
        if (isSamePassword == false)
        {
            throw new BadRequestException("Credenciais inválidas");
        }

        var token = await _tokenService.GenerateToken(user);
        return token;
    }
}
