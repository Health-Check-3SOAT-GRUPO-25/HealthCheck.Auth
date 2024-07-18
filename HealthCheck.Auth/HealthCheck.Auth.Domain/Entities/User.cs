using HealthCheck.Auth.Domain.DTO;
using HealthCheck.Auth.Domain.Enumerators;
using HealthCheck.Auth.Domain.Helpers;
using HealthCheck.Auth.Domain.Validators;

namespace HealthCheck.Auth.Domain.Entities;

public class User : Entity
{
    public string? Cpf { get; private set; }
    public string? Crm { get; private set; }
    public string Name { get; private set; }
    public string? Email { get; private set; }
    public string PasswordHash { get; private set; }
    public virtual UserRole UserRole { get; private set; }

    public User
    (
        string cpf,
        string crm,
        string name,
        string email,
        string passwordHash,
        UserRole userRole
    )
    {
        Cpf = Format.NormalizeCpf(cpf);
        Crm = crm;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        UserRole = userRole;

        ValidateEntity();
    }

    public void SetDetails
    (
        string name,
        string email,
        string passwordHash,
        UserRole userRole
    )
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        UserRole = userRole;

        ValidateEntity();
    }

    public UserDTO AsDto()
    {
        return new UserDTO(this);
    }

    private void ValidateEntity()
    {
        new UserValidator().Validate(this);
    }
}
