using System.ComponentModel.DataAnnotations;

namespace StrataManagementAPI.Models;

public class LoginRequestModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
