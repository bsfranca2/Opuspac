using AutoMapper;
using Opuspac.Core.Entities;

namespace Opuspac.Api.Models.Request;

public class SignInRequestModel
{
    public string Email {  get; set; }
    public string Password { get; set; }
}


public class SignUpRequestModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User ToUser()
    {
        return new User { Name = Name, Email = Email, Password = Password };
    }
}