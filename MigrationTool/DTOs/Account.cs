namespace MigrationTool.DTOs
{
    public class Account
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public UserType segment { get; set; }
        public int segmentId { get; set; }
        public UserType accountStatus { get; set; }
        public int accountStatusId { get; set; }
        public UserType industry { get; set; }
        public int industryId { get; set; }
        public UserType accountType { get; set; }
        public int accountTypeId { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string website { get; set; }
        public string primaryContactName { get; set; }
        public string primaryContactEmail { get; set; }
        public string phone { get; set; }
        public bool isActive { get; set; }
        public bool isDisabled { get; set; }
        public bool isEmailEnabled { get; set; }
        public bool isSmsEnabled { get; set; }
        public bool isSystemNotificationEnabled { get; set; }
        public bool isAccountOnboardingComplete { get; set; }
        public string dateFormat { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOnUtc { get; set; }
        public DateTime modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}