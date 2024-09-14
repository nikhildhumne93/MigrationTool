using System.Security;

namespace MigrationTool.DTOs
{
    public class PageTemplatePermission
    {
        public string id { get; set; }
        public PageTemplate pageTemplate { get; set; }
        public string pageTemplateId { get; set; }
        public Permission permission { get; set; }
        public string permissionId { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}