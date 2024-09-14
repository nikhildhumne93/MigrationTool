using BitMiracle.LibTiff.Classic;
using System.Collections.Generic;

namespace MigrationTool.DTOs
{
    public class Role
    {
        public string id { get; set; }
        public Account account { get; set; }
        public string accountId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public UserType roleType { get; set; }
        public string roleTypeId { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
        public List<RoleXResourcePermissions>roleXResourcePermissions { get; set; }
        public List<RoleXPageTemplatePermissions> roleXPageTemplatePermissions { get; set; }

    }
}