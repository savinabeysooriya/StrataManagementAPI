using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public class BuildingRepository : JsonRepositoryBase<Building>, IBuildingRepository
{
    public BuildingRepository(IConfiguration config)
        : base(config["DatabaseSettings:BuildingsPath"])
    {
    }

    public async Task<List<Building>> GetBuildings()
    {
        return await GetAllAsync();
    }
}
