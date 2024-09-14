namespace MigrationTool.DTOs
{
    public class Resource
    {
       public int id             { get; set; }
       public string title          { get; set; }
       public string description    { get; set; }
       public int displayOrder   { get; set; }
       public bool isActive       { get; set; }
       public bool isAppResource  { get; set; }
       public string createdById    { get; set; }
       public string createdBy      { get; set; }
       public string createdOnUtc   { get; set; }
       public string modifiedOnUtc  { get; set; }
       public string modifiedBy     { get; set; }
       public string modifiedById { get; set; }
    }
}