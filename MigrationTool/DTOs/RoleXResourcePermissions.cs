using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class RoleXResourcePermissions
    {
        public string id { get; set; }
        public string role { get; set; }
        public string roleId { get; set; }
        public ResourcePermission resourcePermission { get; set; }
        public string resourcePermissionId { get; set; }
        public bool isActive { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}
