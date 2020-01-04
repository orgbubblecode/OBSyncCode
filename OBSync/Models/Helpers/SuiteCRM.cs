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
                                                                    (int)OBAPIEnumEntityType.OBUserInformation,
                                                                    (int)OBAPISuiteCRMModuleTypes.Accounts);
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
                    string striCreatedAccountID = (string)oNewAccountrRequestResponse.Data;


                    OBAPIEntitiesTracker oNewTrackedUser = new OBAPIEntitiesTracker();
                    oNewTrackedUser.OBAPIEntityID = User.id.ToString();
                    oNewTrackedUser.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    oNewTrackedUser.OBAPISugarCRMID = striCreatedAccountID;
                    oNewTrackedUser.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Accounts;

                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedUser);
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Detached;



                    //Create Contact 
                    Contact oContactToCreate = new Contact()
                    {
                        FirstName = Models.Helpers.Utilities.NameObject(User.fullname).First,
                        LastName = Models.Helpers.Utilities.NameObject(User.fullname).Last
                    };

                    var oNewConntactRequest = new SugarRestRequest("Contacts", RequestType.Create);
                    oNewConntactRequest.Parameter = oContactToCreate;
                    List<string> selectNewContactFields = new List<string>();
                    selectNewContactFields.Add(nameof(Contact.FirstName));
                    selectNewContactFields.Add(nameof(Contact.LastName));
                    oNewConntactRequest.Options.SelectFields = selectNewContactFields;
                    SugarRestResponse oNewConntactResponse = client.Execute(oNewConntactRequest);

                    string strCreatedContact = (string)oNewConntactResponse.Data;


                    var oLinkAccountToContact = new SugarRestRequest(RequestType.LinkedBulkRead);


                    accounts_contacts oNewaccounts_contacts = new accounts_contacts();

                    oNewaccounts_contacts.id = Guid.NewGuid().ToString();
                    oNewaccounts_contacts.contact_id = strCreatedContact;
                    oNewaccounts_contacts.account_id = striCreatedAccountID;
                    oNewaccounts_contacts.date_modified = DateTime.Now;
                    oNewaccounts_contacts.deleted = false;

                    OBCRMDB.accounts_contacts.Add(oNewaccounts_contacts);
                    OBCRMDB.SaveChanges();






                }

                catch (Exception e)
                {

                    throw;
                }




            }
                else
                {
                    //UPDATE CRM Account

                    




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