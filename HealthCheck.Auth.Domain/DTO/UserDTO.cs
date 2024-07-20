using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Enumerators;
using HealthCheck.Auth.Domain.Helpers;

namespace HealthCheck.Auth.Domain.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole UserRole { get; set; }

    public string UserRoleDescription
    {
        get => UserRole.GetDescription();
    }

    public UserDTO(User user)
    {
        Id = user.Id;
        if (user.Cpf != null)
        {
            Cpf = Format.FormatCpf(user.Cpf);
        }
        if (user.Crm != null)
        {
            Crm = user.Crm;
        }
        Name = user.Name;
        Email = user.Email;
        UserRole = user.UserRole;
    }
}