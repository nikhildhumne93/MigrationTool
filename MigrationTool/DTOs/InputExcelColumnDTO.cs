using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class InputExcelColumnDTO
    {
        public double OrganizationId { get; set; }
        public double ProductId { get; set; }
        public double FormId { get; set; }
        public string Title { get; set; }
        public string FormJsonUrl { get; set; }
        public string Parents { get; set; }
        public double IsActive { get; set; }
        public string FormFileName { get; set; }
        public double AreaOfOperation { get; set; }
        public double FormType { get; set; }
        public double FormSubTypeCategory { get; set; }
        public string Description { get; set; }

    }
}
