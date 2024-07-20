using HealthCheck.Auth.Domain.DTO;

namespace HealthCheck.Auth.Domain.Interface.Services;

public interface IAccountService
{
    Task<AuthenticationResponseDTO> Authenticate(AuthenticationRequestDTO request);
}