using MigrationTool.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    public static class Utility
    {
        public static SqlDataSaveRequestDTO GetSqlDataRequestObject(InputExcelColumnDTO excel)
        {
            SqlDataSaveRequestDTO sqlobj = new SqlDataSaveRequestDTO();
            try
            {
                sqlobj.WorkspaceId = "41fecee1-8622-4745-77a4-08dc2d64ddca";
                sqlobj.Title = excel.Title;
                sqlobj.Description = excel.Description;
                sqlobj.FormTypeId = (int)excel.FormType;
                sqlobj.FormSubTypeId = (int)excel.FormSubTypeCategory;
                sqlobj.IndustryId = 2;
                sqlobj.AreaOfOperationId = (int)excel.AreaOfOperation;
                sqlobj.FormOwnerUserId = "58d1d668-2f44-4dae-85a2-0bf47e09aa76";
                sqlobj.IsSensitiveData = false;
                sqlobj.IsPrePopulate = false;
                sqlobj.IsDraft = false;
                sqlobj.IsTemplate = true;
                sqlobj.IsLocked = true;
                sqlobj.IsNotificationsEnabled = true;
                sqlobj.IsActive = true;
                sqlobj.ApprovalSchema = "OR";
                sqlobj.Parents = "";
                sqlobj.RecieverOnComplete = "";
                sqlobj.Sla = 10;
                sqlobj.IconName = "DynamicFeed";
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.Message);
            }
            return sqlobj;
        }
    }
}
