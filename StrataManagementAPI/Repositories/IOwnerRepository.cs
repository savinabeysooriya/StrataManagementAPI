using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public interface IOwnerRepository
{
    Task<List<Owner>> GetOwners();
}
