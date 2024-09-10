using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class GetTokenRequetDataDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
