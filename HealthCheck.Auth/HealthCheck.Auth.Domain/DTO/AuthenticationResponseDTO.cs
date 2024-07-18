namespace HealthCheck.Auth.Domain.DTO;

public record AuthenticationResponseDTO
(
    UserDTO User,
    string AccessToken
);