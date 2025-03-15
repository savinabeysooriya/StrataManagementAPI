using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public class TenantRepository : JsonRepositoryBase<Tenant>, ITenantRepository
{
    public TenantRepository(IConfiguration config)
    : base(config["DatabaseSettings:TenantsPath"])
    {
    }

    public async Task<List<Tenant>> GetTenants()
    {
        return await GetAllAsync();
    }
}
