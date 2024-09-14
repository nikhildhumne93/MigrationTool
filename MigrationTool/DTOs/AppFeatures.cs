namespace MigrationTool.DTOs
{
    public class AppFeatures
    {
        public string id { get; set; }
        public string app { get; set; }
        public string appId { get; set; }
        public Resource resource { get; set; }
        public int resourceId { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}