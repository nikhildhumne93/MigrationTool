namespace MigrationTool.DTOs
{
    public class Workspace
    {
        public string id { get; set; }
        public Tenant tenant { get; set; }
        public string tenantId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}