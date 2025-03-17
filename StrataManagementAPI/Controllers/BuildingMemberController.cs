using Microsoft.AspNetCore.Mvc;
using StrataManagementAPI.Models;
using StrataManagementAPI.Services;

namespace StrataManagementAPI.Controllers;

[ApiController]
[Route("building-member")]
public class BuildingMemberController(IBuildingMemberService buildingMemberService) : Controller
{

    [HttpPost("maintenance-request")]
    public async Task<IActionResult> CreateMaintenanceRequest([FromBody] MaintenanceRequestModel request)
    {
        var maintenanceRequest = await buildingMemberService.CreateMaintenanceRequest(request);
        return Ok(maintenanceRequest);
    }
}
