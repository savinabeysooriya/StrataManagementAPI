using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;
using System.Security.Claims;

namespace StrataManagementAPI.Services;

public class BuildingMemberService(IBuildingRepository buildingRepository, IMaintenanceRequestRepository maintenanceRequestRepository) : IBuildingMemberService
{
    public Task<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequestModel request, ClaimsPrincipal user)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var maintenanceRequest = new MaintenanceRequest
        {
            Id = Guid.NewGuid().ToString("D"),
            Title = request.Title,
            Description = request.Description,
            AssignedBuildingId = request.AssignedBuildingId,
            Status = RequestStatus.Pending,
            CreatedDate = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        return Task.FromResult(maintenanceRequest);
    }

    public async Task<List<Building>> GetMyBuilding(ClaimsPrincipal user)
    {
        var buildingId = user.FindFirst("buildingId")?.Value;
        var myBuilding = (await buildingRepository.GetBuildings()).FirstOrDefault(i => i.Id == buildingId) ?? throw new Exception("User assigned Building not found");
        return new List<Building> { myBuilding };
    }

    public async Task<List<MaintenanceRequest>> GetMyRequests(ClaimsPrincipal user)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var myRequests = (await maintenanceRequestRepository.GetMaintenanceRequests()).Where(i => i.CreatedByUserId == userId).ToList() ?? throw new Exception("User created Maintenance Requests not found");
        return myRequests;
    }
}
