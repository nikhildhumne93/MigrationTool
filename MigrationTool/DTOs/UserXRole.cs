using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class UserXRole
    {
        public string id { get; set; }
        public Role role { get; set; }
        public string roleId { get; set; }
        public string user { get; set; }
        public string userId { get; set; }
        public Tenant tenant { get; set; }
        public UserGroup userGroup { get; set; }
        public string userGroupId { get; set; }
        public bool isActive { get; set; }
        public string userAccessType { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }

    }
}
