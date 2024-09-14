using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class FormApprover
    {
        public string id { get; set; }
        public string approverId { get; set; }
        public int level { get; set; }
    }
}
