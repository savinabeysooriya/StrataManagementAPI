using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;

namespace StrataManagementAPI.Services;

public class BuildingService(IBuildingRepository buildingRepository) : IBuildingService
{
    public async Task<List<Building>> GetAllBuildings()
    {
        return await buildingRepository.GetAllBuildings();
    }
}
