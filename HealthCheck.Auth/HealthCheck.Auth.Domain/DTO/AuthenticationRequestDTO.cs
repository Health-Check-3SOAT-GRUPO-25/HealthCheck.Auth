namespace HealthCheck.Auth.Domain.DTO;

public record AuthenticationRequestDTO
    (
        string? Cpf,
        string? Crm,
        string? Email,
        string Password
    );