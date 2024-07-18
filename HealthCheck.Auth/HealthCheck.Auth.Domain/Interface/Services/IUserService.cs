using HealthCheck.Auth.Domain.DTO;
using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Enumerators;

namespace HealthCheck.Auth.Domain.Interface.Services;

public interface IUserService
{
    Task<User> GetByIdAsync(Guid userId);

    Task<UserDTO> GetDtoByIdAsync(Guid userId);

    Task<IEnumerable<UserDTO>> GetUsersDtoAsync(UserRole? userRole);

    Task DeleteAsync(Guid userId);

    Task<User> GetByCpfAsync(string cpf);
    Task<User> GetByCrmAsync(string crm);

    Task<User> GetByEmailAsync(string email);
}