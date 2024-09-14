using System.Security.AccessControl;

namespace MigrationTool.DTOs
{
    public class App
    {
        public string id { get; set; }
        public UserType appType { get; set; }
        public string appTypeId { get; set; }
        public string appOwner { get; set; }
        public string appOwnerId { get; set; }
        public Workspace workspace { get; set; }
        public string workspaceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string iconName { get; set; }
        public bool isDraft { get; set; }
        public bool isLocked { get; set; }
        public bool isActive { get; set; }
        public bool isTemplate { get; set; }
        public int segmentId { get; set; }
        public UserType segment { get; set; }
        public UserType industry { get; set; }
        public int industryId { get; set; }
        public int viewCount { get; set; }
        public AppFeatures appFeatures { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}