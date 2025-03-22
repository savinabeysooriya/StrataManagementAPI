using StrataManagementAPI.Models;
using System.Security.Claims;

namespace StrataManagementAPI.Services;

public interface IBuildingMemberService
{
    Task<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequestModel request, ClaimsPrincipal user);
    Task<List<Building>> GetMyBuilding(ClaimsPrincipal user);
    Task<List<MaintenanceRequest>> GetMyRequests(ClaimsPrincipal user);
}
