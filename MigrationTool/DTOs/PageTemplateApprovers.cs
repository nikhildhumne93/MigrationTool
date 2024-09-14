namespace MigrationTool.DTOs
{
    public class PageTemplateApprovers
    {
        public string id { get; set; }
        public string approverId { get; set; }
        public string user { get; set; }
        public string pageTemplateId { get; set; }
        public string pageTemplate { get; set; }
        public int level { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}