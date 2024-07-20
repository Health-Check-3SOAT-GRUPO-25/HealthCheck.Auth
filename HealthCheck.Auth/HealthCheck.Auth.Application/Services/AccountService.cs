using HealthCheck.Auth.Domain.Configurations;
using HealthCheck.Auth.Domain.DTO;
using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Helpers;
using HealthCheck.Auth.Domain.Interface.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace HealthCheck.Auth.Application.Services;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;
    private readonly JwtConfiguration _jwtConfiguration;

    public AccountService(
            IUserService userService,
            IOptions<JwtConfiguration> jwtConfiguration)
    {
        _userService = userService;
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public async Task<AuthenticationResponseDTO> Authenticate(AuthenticationRequestDTO request)
    {
        try
        {
            User user = await GetUser(request);

            ValidateUserLogin(request, user);

            UserDTO userDto = user.AsDto();

            string token = GenerateJwtToken(user);

            return new AuthenticationResponseDTO(userDto, token);
        }
        catch (Exception)
        {
            throw new UnauthorizedAccessException("User not authorized");
        }
    }

    private async Task<User> GetUser(AuthenticationRequestDTO request)
    {
        if (!string.IsNullOrWhiteSpace(request.Crm))
        {
            return await _userService.GetByCrmAsync(request.Crm);
        }
        else
        {
            return await _userService.GetByCpfAsync(request.Cpf ?? string.Empty);
        }
    }

    private static void ValidateUserLogin(AuthenticationRequestDTO request, User user)
    {
        if (!BC.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Incorrect credentials");
        }
    }

    private string GenerateJwtToken(User user)
    {
        SymmetricSecurityKey securityKey = CreateSecurityKey();

        SigningCredentials credentials = CreateCredentials(securityKey);

        Claim[] claims = CreateClaims(user);

        JwtSecurityToken securityToken = CreateSecurityToken(credentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private SymmetricSecurityKey CreateSecurityKey()
    {
        return new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey!)
        );
    }

    private static Claim[] CreateClaims(User user)
    {
        return [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.GetDescription())
        ];
    }

    private static SigningCredentials CreateCredentials(SymmetricSecurityKey securityKey)
    {
        return new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256
        );
    }

    private JwtSecurityToken CreateSecurityToken(SigningCredentials credentials, Claim[] claims)
    {
        return new JwtSecurityToken
        (
            _jwtConfiguration.Issuer,
            _jwtConfiguration.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );
    }
}