
namespace MigrationTool.DTOs
{
    public class UserGroupsXResources
    {
        public string id { get; set; }
        public string userGroup { get; set; }
        public string userGroupId { get; set; }
        public string resourceId { get; set; }
        public string resourceTypeId { get; set; }
        public Resource resourceType { get; set; }
    }
}