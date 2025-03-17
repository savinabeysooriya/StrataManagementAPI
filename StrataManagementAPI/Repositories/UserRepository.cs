using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public class UserRepository : JsonRepositoryBase<User>, IUserRepository
{
    public UserRepository(IConfiguration config)
    : base(config["DatabaseSettings:UsersPath"])
    {
    }

    public async Task<User?> GetByUserName(string username)
    {
        var users = await GetAllAsync();
        return users.FirstOrDefault(i => i.Username == username);
    }
}
