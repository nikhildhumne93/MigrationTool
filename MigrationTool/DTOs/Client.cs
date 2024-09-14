using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.DTOs
{
    public class Client
    {
        public string id { get; set; }
        public Account account { get; set; }
        public string accountId { get; set; }
        public string title { get; set; }
        public string accountNumber { get; set; }
        public string dateBecameClient { get; set; }
        public string description { get; set; }
        public string parentClientId { get; set; }
        public UserType segment { get; set; }
        public string MyProsegmentIdperty { get; set; }
        public UserType clientStatus { get; set; }
        public string clientStatusId { get; set; }
        public UserType industry { get; set; }
        public string industryId { get; set; }
        public UserType clientType { get; set; }
        public string clientTypeId { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string logo { get; set; }
        public string logoURl { get; set; }
        public bool isDisabled { get; set; }
        public bool isActive { get; set; }
        public string accountManagedByRole { get; set; }
        public string accountManagedByRoleId { get; set; }
        public string accountOwner { get; set; }
        public string accountOwnerId { get; set; }
        public string relationshipManager { get; set; }
        public string relationshipManagerId { get; set; }
        public string salesExecutive { get; set; }
        public string salesExecutiveId { get; set; }
        public string duns { get; set; }
        public string dunS_Buisness_Name { get; set; }
        public string gud { get; set; }
        public string guD_Buisnesss_Name { get; set; }
        public string domestic_DUNS { get; set; }
        public string domestic_DUNS_Buisness_Name { get; set; }
        public string assets { get; set; }
        public string members { get; set; }
        public string assetClass { get; set; }
        public string efficiencyRatio { get; set; }
        public string potential { get; set; }
        public string performance { get; set; }
        public string relationshipStatus { get; set; }
        public string overallAccountHealth { get; set; }
        public string overallAccountHealthChangedToRed { get; set; }
        public string overallAccountHealthComments { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string createdOnUtc { get; set; }
        public string modifiedOnUtc { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedById { get; set; }
    }
}
