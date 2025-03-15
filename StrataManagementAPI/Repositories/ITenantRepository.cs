using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public interface ITenantRepository
{
    Task<List<Tenant>> GetTenants();
}
