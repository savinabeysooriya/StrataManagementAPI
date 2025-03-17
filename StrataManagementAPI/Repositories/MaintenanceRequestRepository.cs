using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public class MaintenanceRequestRepository : JsonRepositoryBase<MaintenanceRequest>, IMaintenanceRequestRepository
{
    public MaintenanceRequestRepository(IConfiguration config)
       : base(config["DatabaseSettings:MaintenanceRequestsPath"])
    {
    }

    public async Task<List<MaintenanceRequest>> GetMaintenanceRequests()
    {
        return await GetAllAsync();
    }
}
