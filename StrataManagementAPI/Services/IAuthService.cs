using StrataManagementAPI.Models;

namespace StrataManagementAPI.Services;

public interface IAuthService
{
    Task<AuthResult> Login(string username, string password);
}
