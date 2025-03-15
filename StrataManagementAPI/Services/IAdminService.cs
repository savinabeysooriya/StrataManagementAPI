using StrataManagementAPI.Models;

namespace StrataManagementAPI.DataAccess;

public interface IAdminService
{
    Task <List<Building>> GetBuildings();
    Task<List<Owner>> GetOwners();
    Task<List<Tenant>> GetTenants();
}
