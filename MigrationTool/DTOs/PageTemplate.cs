using System.Security.Principal;

namespace MigrationTool.DTOs
{
    public class PageTemplate
    {
        public string id { get; set; }
        public Account account { get; set; }
        public string accountId { get; set; }
        public Tenant tenant { get; set; }
        public string tenantId { get; set; }
        public Workspace workspace { get; set; }
        public string workspaceId { get; set; }
        public App app { get; set; }
        public string appId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public UserType pageTemplateType { get; set; }
        public int pageTemplateTypeId { get; set; }
        public bool isBulkUploadAllowed { get; set; }
        public bool isDeleteAllowed { get; set; }
        public bool isSubmissionAllowedFromUI { get; set; }
        public bool isNotificationsEnabled { get; set; }
        public bool isSensitiveData { get; set; }
        public bool isPrePopulate { get; set; }
        public bool isAppsHomePage { get; set; }
        public string formFieldListJson { get; set; }
        public string searchByFormFieldJson { get; set; }
        public bool isDraft { get; set; }
        public bool isLocked { get; set; }
        public int sla { get; set; }
        public PageTemplateApprovers pageTemplateApprovers { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string approvalSchema { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}