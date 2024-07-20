using HealthCheck.Auth.Domain.DTO;
using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Enumerators;
using HealthCheck.Auth.Domain.Helpers;
using HealthCheck.Auth.Domain.Interface.Repositories;
using HealthCheck.Auth.Domain.Interface.Services;

namespace HealthCheck.Auth.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByCpfAsync(string cpf)
    {
        cpf = Format.NormalizeCpf(cpf);

        User? user = await _userRepository.FindFirstDefaultAsync(x => x.Cpf == cpf);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task DeleteAsync(Guid userId)
    {
        User? user = await _userRepository.FindFirstDefaultAsync(x => x.Id == userId);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        _userRepository.Remove(user);
    }

    public async Task<User> GetByIdAsync(Guid userId)
    {
        User? user = await _userRepository.FindFirstDefaultAsync(x => x.Id == userId);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<UserDTO> GetDtoByIdAsync(Guid userId)
    {
        User user = await GetByIdAsync(userId);

        return user.AsDto();
    }

    public async Task<IEnumerable<UserDTO>> GetUsersDtoAsync(UserRole? userRole)
    {
        var users = (userRole == null)
            ? await _userRepository.GetAllAsync()
            : await _userRepository.FindAsync(x => x.UserRole == userRole);

        return users.Select(user => user.AsDto());
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        User? user = await _userRepository.FindFirstDefaultAsync(x => x.Email == email.Trim());

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<User> GetByCrmAsync(string crm)
    {
        User? user = await _userRepository.FindFirstDefaultAsync(x => x.Crm == crm);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }
}
