using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class FormOwner
    {
        public string id { get; set; }
        public Account account { get; set; }
        public string accountId { get; set; }
        public  Client client { get; set; }
        public string clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public UserType userType { get; set; }
        public int userTypeId { get; set; }
        public string userName { get; set; }
        public string objectId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool isDistributionUser { get; set; }
        public string ftp { get; set; }
        public bool isActive { get; set; }
        public bool isDisabled { get; set; }
        public bool isEmailEnabled { get; set; }
        public bool isSmsEnabled { get; set; }
        public bool isSystemNotificationEnabled { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOnUtc { get; set; }
        public DateTime modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
        public List<UserXRole> userXRoles { get; set; }
    }
}
