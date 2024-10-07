using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.CRM.ESPOCRM
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string createdAt { get; set; }

        public string id { get; set; }
    }


    public class ContactsSearchResult
    {
        public int total { get; set; }
        public List[] list { get; set; }
    }

    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
        public object salutationName { get; set; }
        public object firstName { get; set; }
        public string lastName { get; set; }
        public object title { get; set; }
        public object description { get; set; }
        public string emailAddress { get; set; }
        public object phoneNumber { get; set; }
        public bool doNotCall { get; set; }
        public object addressStreet { get; set; }
        public object addressCity { get; set; }
        public object addressState { get; set; }
        public object addressCountry { get; set; }
        public object addressPostalCode { get; set; }
        public object accountIsInactive { get; set; }
        public object accountType { get; set; }
        public string createdAt { get; set; }
        public string modifiedAt { get; set; }
        public bool hasPortalUser { get; set; }
        public object middleName { get; set; }
        public bool emailAddressIsOptedOut { get; set; }
        public bool emailAddressIsInvalid { get; set; }
        public object phoneNumberIsOptedOut { get; set; }
        public object phoneNumberIsInvalid { get; set; }
        public object accountId { get; set; }
        public object accountName { get; set; }
        public object campaignId { get; set; }
        public object campaignName { get; set; }
        public string createdById { get; set; }
        public string createdByName { get; set; }
        public object modifiedById { get; set; }
        public object modifiedByName { get; set; }
        public object assignedUserId { get; set; }
        public object assignedUserName { get; set; }
        public object portalUserId { get; set; }
        public object portalUserName { get; set; }
        public object originalLeadId { get; set; }
        public object originalLeadName { get; set; }
    }



}
