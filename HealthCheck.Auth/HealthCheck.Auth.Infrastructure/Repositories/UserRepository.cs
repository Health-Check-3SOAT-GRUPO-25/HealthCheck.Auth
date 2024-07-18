using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Interface.Repositories;
using HealthCheck.Auth.Infrastructure.Context;
using HealthCheck.Auth.Infrastructure.RepositoriesStandard;

namespace HealthCheck.Auth.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : DomainRepository<User>(applicationDbContext), IUserRepository
{
}