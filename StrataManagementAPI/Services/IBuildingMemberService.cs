using StrataManagementAPI.Models;
using System.Security.Claims;

namespace StrataManagementAPI.Services;

public interface IBuildingMemberService
{
    Task<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequestModel request);
    Task<List<Building>> GetMyBuilding(ClaimsPrincipal user);
}
