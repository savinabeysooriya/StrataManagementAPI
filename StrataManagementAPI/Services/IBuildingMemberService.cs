using StrataManagementAPI.Models;

namespace StrataManagementAPI.Services;

public interface IBuildingMemberService
{
    Task<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequestModel request);
}
