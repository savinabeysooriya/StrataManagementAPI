using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StrataManagementAPI.DataAccess;

namespace StrataManagementAPI.Controllers;

[ApiController]
[Route("admin")]
public class AdminController(IAdminService adminService) : ControllerBase
{
    [HttpGet("buildings")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetBuildings()
    {
        var buildings = await adminService.GetBuildings();
        return Ok(buildings);
    }

    [HttpGet("owners")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetOwners()
    {
        var owners = await adminService.GetOwners();
        return Ok(owners);
    }

    [HttpGet("tenants")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetTenants()
    {
        var tenants = await adminService.GetTenants();
        return Ok(tenants);
    }

    [HttpGet("maintenance-requests")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetMaintenanceRequests()
    {
        var maintenanceRequests = await adminService.GetMaintenanceRequests();
        return Ok(maintenanceRequests);
    }

}
