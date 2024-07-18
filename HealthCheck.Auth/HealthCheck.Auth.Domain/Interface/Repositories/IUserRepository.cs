using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Interface.RepositoriesStandard;

namespace HealthCheck.Auth.Domain.Interface.Repositories;

public interface IUserRepository : IDomainRepository<User>
{
}