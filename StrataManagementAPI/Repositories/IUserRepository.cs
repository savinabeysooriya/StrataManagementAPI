using StrataManagementAPI.Models;

namespace StrataManagementAPI.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUserName(string username);
}
