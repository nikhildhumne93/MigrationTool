namespace MigrationTool.DTOs
{
    public class UserType
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int displayOrder { get; set; }
        public bool isActive { get; set; }
    }
}