using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public interface IMaintenanceRequestRepository
{
    Task<List<MaintenanceRequest>> GetMaintenanceRequests();
}
