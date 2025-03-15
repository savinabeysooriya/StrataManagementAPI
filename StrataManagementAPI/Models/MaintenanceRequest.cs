namespace StrataManagementAPI.Models
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public int CreatedByUserId { get; set; }
        public int AssignedBuildingId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
