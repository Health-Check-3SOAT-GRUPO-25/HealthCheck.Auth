using HealthCheck.Auth.Domain.Interface.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HealthCheck.Auth.Application.Services;

public class AuthenticatedUser(IHttpContextAccessor httpContextAccessor) : IAuthenticatedUser
{
    private readonly ClaimsPrincipal _authenticatedUser = httpContextAccessor.HttpContext!.User;

    public Guid Id => Guid.Parse(_authenticatedUser.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}