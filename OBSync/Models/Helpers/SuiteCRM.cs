using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SugarRestSharp;

using AllMyBio;
using OrgBubble;
using OBSync.Models.OBDataSources;

using OBSync.Models;
using SugarRestSharp;
using SugarRestSharp.Models;

using Elmah;
using RestSharp;
using Newtonsoft.Json;

namespace OBSync.Models.Helpers
{
    public class SuiteCRM
    {

        static private AllMyBioDbEntities ambDb = new AllMyBioDbEntities();
        static private OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();
        static private OBSyncOLTP OBSyncDB = new OBSyncOLTP();
        static private OBCRMDbEntities OBCRMDB = new OBCRMDbEntities();


        public static SugarRestClient GetSuiteCRMClient()
        {

            // sugarCRM project site: 
            string sugarCrmUrl = "https://crm.orgbubble.com/service/v4_1/rest.php";
            string sugarCrmUsername = "obapiuser";
            string sugarCrmPassword = "Th34piUs3770";

            return new SugarRestClient(sugarCrmUrl, sugarCrmUsername, sugarCrmPassword);


        }


        public static List<OBAPIResponse> UpdateOrgBubbleUsersBasicInformation()
        {


            List<OBAPIResponse> Responses = new List<OBAPIResponse>();
            List<OrgBubble.general_users> obLst = new List<OrgBubble.general_users>();
            obLst = obDb.general_users.ToList();


            if (obLst.Count > 0)
            {

                foreach (var oOBUser in obLst)
                {

                    OBAPIResponse response = UpdateOrgBubbleUsersBasicInformation(oOBUser);
                    Responses.Add(response);

                }
            }
            return Responses;
                       



        }



            public static OBAPIResponse UpdateOrgBubbleUsersBasicInformation(general_users User) 
            {


                OBAPIEntitiesTracker oTrackedUser = GetSuiteCRMRecordID(User.id.ToString(),
                                                                       (int)OBAPIEnumEntityType.OBAccount,
                                                                       (int)OBAPISuiteCRMModuleTypes.Accounts);

                string strAccountID = "";
                string strContactID = "";
                string strEmailAddressID = "";
                string strBeanID = "";
                string strAccountContactID = "";

                OBAPIResponse Response = new OBAPIResponse();
                var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();

                if (String.IsNullOrEmpty(oTrackedUser.OBAPISugarCRMID))
                {
                
                //Add CRM Account
                try
                {

                    Account oNewAccount = new Account()
                    {
                        Name = User.email.ToUpper(),
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba"
                    };
                    var oNewAccountrRequest = new SugarRestRequest("Accounts", RequestType.Create);
                    oNewAccountrRequest.Parameter = oNewAccount;
                    List<string> selectNewAccountFields = new List<string>();
                    selectNewAccountFields.Add(nameof(Account.Name));
                    selectNewAccountFields.Add(nameof(Account.AssignedUserId));
                    oNewAccountrRequest.Options.SelectFields = selectNewAccountFields;
                    SugarRestResponse oNewAccountrRequestResponse = client.Execute(oNewAccountrRequest);
                    strAccountID = (string)oNewAccountrRequestResponse.Data;


                    //Account Tracker
                    OBAPIEntitiesTracker oNewTrackedAccount = new OBAPIEntitiesTracker();
                    oNewTrackedAccount.OBAPIEntityID = User.id.ToString();
                    oNewTrackedAccount.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    oNewTrackedAccount.OBAPISugarCRMID = strAccountID;
                    oNewTrackedAccount.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Accounts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccount);
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Detached;



                    //Create Contact 
                    Contact oContactToCreate = new Contact()
                    {
                        FirstName = Models.Helpers.Utilities.NameObject(User.fullname).First,
                        LastName = Models.Helpers.Utilities.NameObject(User.fullname).Last,
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba"
                    };
                    var oNewConntactRequest = new SugarRestRequest("Contacts", RequestType.Create);
                    oNewConntactRequest.Parameter = oContactToCreate;
                    List<string> selectNewContactFields = new List<string>();
                    selectNewContactFields.Add(nameof(Contact.FirstName));
                    selectNewContactFields.Add(nameof(Contact.LastName));
                    oNewConntactRequest.Options.SelectFields = selectNewContactFields;
                    SugarRestResponse oNewConntactResponse = client.Execute(oNewConntactRequest);
                    strContactID = (string)oNewConntactResponse.Data;

                    //Contact Tracker
                    OBAPIEntitiesTracker oNewTrackedUser = new OBAPIEntitiesTracker();
                    oNewTrackedUser.OBAPIEntityID = User.id.ToString();
                    oNewTrackedUser.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    oNewTrackedUser.OBAPISugarCRMID = strContactID;
                    oNewTrackedUser.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Contacts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedUser);
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Detached;





                    //AccountsContacts oAccountContact = new AccountsContacts()
                    //{
                    //    ContactId = strContactID,
                    //    AccountId = strAccountID,
                    //    Deleted = 0,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oAccountContactRequest = new SugarRestRequest("AccountsContacts", RequestType.Create);
                    //oAccountContactRequest.Parameter = oAccountContact;
                    //List<string> selectAccountContacFields = new List<string>();
                    //selectAccountContacFields.Add(nameof(AccountsContacts.ContactId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.AccountId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.Deleted));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.DateModified));
                    //oAccountContactRequest.Options.SelectFields = selectAccountContacFields;
                    //SugarRestResponse oAccountContactResponse = client.Execute(oAccountContactRequest);
                    //strAccountContactID = (string)oAccountContactResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedAccountContact = new OBAPIEntitiesTracker();
                    //oNewTrackedAccountContact.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedAccountContact.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    //oNewTrackedAccountContact.OBAPISugarCRMID = strAccountContactID;
                    //oNewTrackedAccountContact.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.AccountContacts;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccountContact);
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Detached;



                    //EmailAddresses oContactEmail = new EmailAddresses()
                    //{
                    //    EmailAddress = User.email,
                    //    EmailAddressCaps = User.email.ToUpper(),
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oNewEmailRequest = new SugarRestRequest("EmailAddresses", RequestType.Create);
                    //oNewEmailRequest.Parameter = oContactEmail;
                    //List<string> selectNewEmailAddressFieldsFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddressCaps));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateModified));
                    //oNewEmailRequest.Options.SelectFields = selectNewEmailAddressFieldsFields;
                    //SugarRestResponse oNewEmailResponse = client.Execute(oNewEmailRequest);
                    //strEmailAddressID = (string)oNewEmailResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedEmailAddress = new OBAPIEntitiesTracker();
                    //oNewTrackedEmailAddress.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedEmailAddress.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserEmailAddress;
                    //oNewTrackedEmailAddress.OBAPISugarCRMID = strEmailAddressID;
                    //oNewTrackedEmailAddress.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddresses;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedEmailAddress);
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Detached;




                    //EmailAddrBeanRel oContactEmailBeanRelation = new EmailAddrBeanRel()
                    //{
                    //    EmailAddressId = strEmailAddressID,
                    //    BeanId = strContactID,
                    //    BeanModule = "Contacts",
                    //    PrimaryAddress = 1,
                    //    ReplyToAddress=0,
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //    Deleted = 0

                    //};
                    //var oContactEmailBeanRelationRequest = new SugarRestRequest("EmailAddrBeanRel", RequestType.Create);
                    //oContactEmailBeanRelationRequest.Parameter = oContactEmailBeanRelation;
                    //List<string> selectContactEmailBeanRelationFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.EmailAddressId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.BeanId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.PrimaryAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.ReplyToAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.Deleted));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateModified));
                    //oContactEmailBeanRelationRequest.Options.SelectFields = selectContactEmailBeanRelationFields;
                    //SugarRestResponse oNewEmailBeanResponse = client.Execute(oContactEmailBeanRelationRequest);
                    //strBeanID = (string)oNewEmailBeanResponse.Data;
                    ////Contact Tracker
                    //OBAPIEntitiesTracker oNewTrackedBean = new OBAPIEntitiesTracker();
                    //oNewTrackedBean.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedBean.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    //oNewTrackedBean.OBAPISugarCRMID = strBeanID;
                    //oNewTrackedBean.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddressesBeans;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedBean);
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Detached;






                    //Add Contact To Account
                    accounts_contacts oNewaccounts_contacts = new accounts_contacts();
                    oNewaccounts_contacts.id = Guid.NewGuid().ToString();
                    oNewaccounts_contacts.contact_id = strContactID;
                    oNewaccounts_contacts.account_id = strAccountID;
                    oNewaccounts_contacts.date_modified = DateTime.Now;
                    oNewaccounts_contacts.deleted = false;
                    OBCRMDB.accounts_contacts.Add(oNewaccounts_contacts);
                    OBCRMDB.SaveChanges();


                    //Add Email To Contact
                    email_addresses oUserContactEmail = new email_addresses();
                    Guid gEmailID = Guid.NewGuid();
                    oUserContactEmail.id = gEmailID;
                    oUserContactEmail.email_address = User.email;
                    oUserContactEmail.email_address_caps = User.email.ToUpper();
                    oUserContactEmail.invalid_email = false;
                    oUserContactEmail.opt_out = false;
                    oUserContactEmail.confirm_opt_in = "confirmed-opt-in";
                    oUserContactEmail.date_created = DateTime.Now;
                    oUserContactEmail.date_modified = DateTime.Now;
                    oUserContactEmail.deleted = false;
                    OBCRMDB.email_addresses.Add(oUserContactEmail);
                    OBCRMDB.SaveChanges();







                    //  request.Options.Query = String.Concat("contacts.id IN (SELECT bean_id FROM email_addr_bean_rel eabr JOIN email_addresses ea ON (eabr.email_address_id = ea.id) WHERE bean_module = 'Contacts' AND ea.email_address_caps = '", oOBUser.email, "' AND eabr.deleted=0)");
                    //request.Options.QueryPredicates = new List<QueryPredicate>();



                }

                catch (Exception e)
                {

                    throw;
                }




            }
                else
                {
                    //UPDATE CRM Account

                    
                var readAccountRequest = new SugarRestRequest("Accounts", RequestType.ReadById);
                strAccountID = oTrackedUser.OBAPISugarCRMID;
                readAccountRequest.Parameter = strAccountID;
                SugarRestResponse accountReadResponse = client.Execute(readAccountRequest);
                Account oAccountToUpdate = (Account)accountReadResponse.Data;

                var updateAccountRequest = new SugarRestRequest(RequestType.Update);
                oAccountToUpdate.Name = User.email.ToUpper();
                updateAccountRequest.Parameter = oAccountToUpdate;
                List<string> selectAccountToUpdateFields = new List<string>();
                selectAccountToUpdateFields.Add(nameof(Account.Name));
                updateAccountRequest.Options.SelectFields = selectAccountToUpdateFields;
                SugarRestResponse responseAccountUpdate = client.Execute<Account>(updateAccountRequest);

            



            }




            //Update Customs
            if (!String.IsNullOrEmpty(strAccountID))
            { 
                Guid oAccountID = new Guid(strAccountID);
                accounts_cstm oCRMAccountCustomInfo = OBCRMDB.accounts_cstm.Where(w => w.id_c == oAccountID).FirstOrDefault();

                if (oCRMAccountCustomInfo != null)
                {
                    oCRMAccountCustomInfo.isorgbubblecustomer_c = true;
                    oCRMAccountCustomInfo.orgbubbleid_c = User.id;
                    oCRMAccountCustomInfo.orgbubblepackage_c = obDb.general_packages.SingleOrDefault(w => w.id == User.package).name;
                    oCRMAccountCustomInfo.isorgbubbleactive_c = (User.status == 1 ? true : false);

                    OBCRMDB.accounts_cstm.Add(oCRMAccountCustomInfo);
                    OBCRMDB.Entry(oCRMAccountCustomInfo).State = System.Data.Entity.EntityState.Modified;
                    OBCRMDB.SaveChanges();
                }
            }







            return Response;


            }







            public static OBAPIEntitiesTracker GetSuiteCRMRecordID(string OBAPIEntityID, 
                                                                      int OBAPIEntityTypeID,
                                                                      int OBAPISugarModuleID)
            {
                
                OBAPIEntitiesTracker oTracker = OBSyncDB.OBAPIEntitiesTrackers
                                                        .Where(w => w.OBAPIEntityID == OBAPIEntityID 
                                                        && w.OBAPIEntityTypeID == OBAPIEntityTypeID 
                                                        && w.OBAPISugarModuleID == OBAPISugarModuleID).FirstOrDefault();
                
                if(oTracker != null)
                {
                    return oTracker;
                }

                return new OBAPIEntitiesTracker();


            }













    }
}