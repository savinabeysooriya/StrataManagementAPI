using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public class OwnerRepository : JsonRepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(IConfiguration config)
        : base(config["DatabaseSettings:OwnersPath"])
    {
    }

    public async Task<List<Owner>> GetOwners()
    {
        return await GetAllAsync();
    }
}