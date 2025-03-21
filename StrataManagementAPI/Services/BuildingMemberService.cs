using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;
using System.Security.Claims;

namespace StrataManagementAPI.Services;

public class BuildingMemberService(IBuildingRepository buildingRepository) : IBuildingMemberService
{
    public Task<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequestModel request)
    {
        var maintenanceRequest = new MaintenanceRequest
        {
            Id = Guid.NewGuid().ToString("D"),
            Title = request.Title,
            Description = request.Description,
            AssignedBuildingId = request.AssignedBuildingId,
            Status = RequestStatus.Pending,
            CreatedDate = DateTime.UtcNow,
            CreatedByUserId = "iD"
        };

        return Task.FromResult(maintenanceRequest);
    }

    public async Task<List<Building>> GetMyBuilding(ClaimsPrincipal user)
    {
        var buildingId = user.FindFirst("buildingId")?.Value;
        var myBuilding = (await buildingRepository.GetBuildings()).FirstOrDefault(i => i.Id == buildingId) ?? throw new Exception("User assigned Building not found");
        return new List<Building> { myBuilding };
    }
}
