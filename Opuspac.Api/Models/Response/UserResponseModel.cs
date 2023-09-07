using Opuspac.Core.Entities;

namespace Opuspac.Api.Models.Response;

public class UserResponseModel : User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserResponseModel(User user) : base()
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}