namespace StrataManagementAPI.Models
{
    public class MaintenanceRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public string CreatedByUserId { get; set; }
        public string AssignedBuildingId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
