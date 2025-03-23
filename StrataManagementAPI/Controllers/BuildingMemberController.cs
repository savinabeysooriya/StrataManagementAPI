using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StrataManagementAPI.Models;
using StrataManagementAPI.Services;

namespace StrataManagementAPI.Controllers;

[ApiController]
[Route("building-member")]
public class BuildingMemberController(IBuildingMemberService buildingMemberService) : Controller
{

    [HttpPost("maintenance-request")]
    [Authorize(Policy = "BuildingMember")]
    public async Task<IActionResult> CreateMaintenanceRequest([FromBody] MaintenanceRequestModel request)
    {
        var maintenanceRequest = await buildingMemberService.CreateMaintenanceRequest(request, User);
        return Ok(maintenanceRequest);
    }

    [HttpGet("my-building")]
    [Authorize(Policy = "BuildingMember")]
    public async Task<IActionResult> GetMyBuilding()
    {
        var buildings = await buildingMemberService.GetMyBuilding(User);
        return Ok(buildings);
    }

    [HttpGet("my-requests")]
    [Authorize(Policy = "BuildingMember")]
    public async Task<IActionResult> GetMyRequests()
    {
        var maintenanceRequests = await buildingMemberService.GetMyRequests(User);
        return Ok(maintenanceRequests);
    }
}
