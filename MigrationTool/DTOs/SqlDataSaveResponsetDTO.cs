using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class SqlDataSaveResponsetDTO
    {
        public string id { get; set; }
        public string workspaceTitle { get; set; }
        public string workspaceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string iconName { get; set; }
        public string formTypeTitle { get; set; }
        public int formTypeId { get; set; }
        public string formSubTypeTitle { get; set; }
        public int formSubTypeId { get; set; }
        public string industryTitle { get; set; }
        public int industryId { get; set; }
        public int sla { get; set; }
        public string areaOfOperationTitle { get; set; }
        public int areaOfOperationId { get; set; }
        public string formOwnerUserId { get; set; }
        public FormOwner formOwner { get; set; }
        public string parents { get; set; }
        public string recieverOnComplete { get; set; }
        public int version { get; set; }
        public string formFieldListJson { get; set; }
        public string approvalSchema { get; set; }
        public string searchByFormFieldJson { get; set; }
        public bool isSensitiveData { get; set; }
        public bool isNotificationsEnabled { get; set; }
        public bool isPrePopulate { get; set; }
        public bool isDraft { get; set; }
        public bool isLocked { get; set; }
        public bool isActive { get; set; }
        public bool isTemplate { get; set; }
        public int publishedCount { get; set; }
        public int viewCount { get; set; }
        public string formPublishRefIdStart { get; set; }
        public string formPublishRefIdRuleTitle { get; set; }
        public int formPublishRefIdRuleId { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
        public List<FormApprover> formApprovers { get; set; }
    }
}
