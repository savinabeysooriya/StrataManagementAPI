using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;

namespace StrataManagementAPI.Services;

public class AdminService(IBuildingRepository buildingRepository, IOwnerRepository ownerRepository, ITenantRepository tenantRepository) : IAdminService
{
    public async Task<List<Building>> GetBuildings()
    {
        return await buildingRepository.GetBuildings();
    }

    public async Task<List<Owner>> GetOwners()
    {
        return await ownerRepository.GetOwners();
    }

    public async Task<List<Tenant>> GetTenants()
    {
        return await tenantRepository.GetTenants();
    }
}
