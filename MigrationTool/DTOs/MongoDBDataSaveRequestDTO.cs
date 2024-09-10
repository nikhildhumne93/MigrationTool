using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class MongoDBDataSaveRequestDTO
    {
        public string FormId { get; set; }
        public string FormJson { get; set; }
        public string PrefillData { get; set; }
    }
}
