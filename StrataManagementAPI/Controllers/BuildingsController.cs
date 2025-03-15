using Microsoft.AspNetCore.Mvc;
using StrataManagementAPI.DataAccess;

namespace StrataManagementAPI.Controllers;

[ApiController]
[Route("building")]
public class BuildingsController(IBuildingService buildingService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var buildings = await buildingService.GetAllBuildings();
        return Ok(buildings);
    }
}
