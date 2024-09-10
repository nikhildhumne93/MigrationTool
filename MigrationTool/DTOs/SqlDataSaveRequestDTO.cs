using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class SqlDataSaveRequestDTO
    {
        //"41fecee1-8622-4745-77a4-08dc2d64ddca",
        public string WorkspaceId { get; set; }
        //column  D  Title
        public string Title { get; set; }

        //column  L  Description
        public string Description { get; set; }
        //column j  Form Type
        public int FormTypeId { get; set; }

        //column  K Form Sub Type / Category
        public int FormSubTypeId { get; set; }

        //Default value "2"
        public int IndustryId { get; set; }
        //column I AreaOfOperationId
        public int AreaOfOperationId { get; set; }

        //"58d1d668-2f44-4dae-85a2-0bf47e09aa76"
        public string FormOwnerUserId { get; set; }
        //false
        public bool IsSensitiveData { get; set; }
        //false
        public bool IsPrePopulate { get; set; }
        //false
        public bool IsDraft { get; set; }
        //true
        public bool IsTemplate { get; set; }
        //true
        public bool IsLocked { get; set; }
        //true
        public bool IsNotificationsEnabled { get; set; }
        //true
        public bool IsActive { get; set; }
        //Default "OR" 
        public string ApprovalSchema { get; set; }
        //default ""
        public string Parents { get; set; }
        //default ""
        public string RecieverOnComplete { get; set; }
        //default 10
        public int Sla { get; set; }
        // "DynamicFeed"
        public string IconName { get; set; }

    }
}
