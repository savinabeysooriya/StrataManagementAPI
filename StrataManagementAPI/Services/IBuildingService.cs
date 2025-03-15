using StrataManagementAPI.Models;

namespace StrataManagementAPI.DataAccess;

public interface IBuildingService
{
    Task <List<Building>> GetAllBuildings();
}
