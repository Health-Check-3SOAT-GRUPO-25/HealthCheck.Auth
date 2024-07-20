using HealthCheck.Auth.Domain.DTO;
using HealthCheck.Auth.Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthCheck.Auth.API.Controllers.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController(
    IAccountService accountService,
    IAuthenticatedUser authenticatedUser) : ControllerBase
{
    [HttpPost("Login")]
    [SwaggerOperation(Summary = "User login", Description = "Authenticate user and return access token.")]
    [ProducesResponseType(typeof(AuthenticationResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestDTO request)
    {
        var response = await accountService.Authenticate(request);
        return Ok(response);
    }
}