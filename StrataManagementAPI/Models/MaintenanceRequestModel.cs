using System.ComponentModel.DataAnnotations;

namespace StrataManagementAPI.Models;

public class MaintenanceRequestModel
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }

    [Required]
    public string AssignedBuildingId { get; set; }
}
