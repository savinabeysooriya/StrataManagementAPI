﻿namespace StrataManagementAPI.Models;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }  
    public string BuildingId { get; set; } 
}
