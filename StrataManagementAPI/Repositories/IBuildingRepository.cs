using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public interface IBuildingRepository
{
    Task<List<Building>> GetAllBuildings();
}
