using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class MongoDBDataSaveDataResponseDTO
    {
        public string id { get; set; }
        public string formId { get; set; }
        public string formJson { get; set; }
        public string prefillData { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOnUtc { get; set; }
        public DateTime modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}






