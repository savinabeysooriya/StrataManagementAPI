using StrataManagementAPI.Models;

namespace StrataManagementAPI.Services;

public class BuildingMemberService : IBuildingMemberService
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
}
