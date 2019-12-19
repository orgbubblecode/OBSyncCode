using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AllMyBio;
using OrgBubble;
using OBSync.Models.OBDataSources;

using OBSync.Models;
using SugarRestSharp;
using SugarRestSharp.Models;

using Elmah;
using RestSharp;
using Newtonsoft.Json;

namespace OBSync.Controllers
{

    public class CRMOpsController : ApiController
    {
        private AllMyBioDbEntities ambDb = new AllMyBioDbEntities();
        private OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();
        private OBSyncOLTP OBSyncDB = new OBSyncOLTP();


 
        [Route("api/CRMOps/CheckDatabaseConnectivity")]
        [HttpPost]
        public OBAPIResponse CheckDatabaseConnectivity(string OBAuthCode)
        {


            OBAPIResponse Response = new OBAPIResponse();



            try
            {

           

            var list = new List<KeyValuePair<string, bool>>() {
                 new KeyValuePair<string, bool>(obDb.Database.Connection.Database, obDb.Database.Exists()),
                 new KeyValuePair<string, bool>(ambDb.Database.Connection.Database, ambDb.Database.Exists())
            };


                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
                IPAddress ipAddress = ipHostInfo.AddressList[0];


                Response.success = obDb.Database.Exists() && ambDb.Database.Exists();
                Response.data = list;
                Response.message = "Calling MySQL databases from:" + ipAddress.ToString();


                OBSyncDB.OBAPIResponses.Add(Response);
                OBSyncDB.SaveChanges();
                

                return Response;

            }
            catch (Exception e)
            {

                ErrorSignal.FromCurrentContext().Raise(e);
                return Response;
                throw;
            }

            


        }




        [Route("api/CRMOps/SyncOBUsers")]
        [HttpPost]
        public OBAPIResponse SyncOBUsers()
        {




            

            //string sugarCrmUrl = "https://crm.orgbubble.com/service/v4_1/rest.php";
            //string sugarCrmUsername = "obapiuser";
            //string sugarCrmPassword = "Th34piUs3770";


            //string user_name = "obapiuser"; string password = "Th34piUs3770";
            //var paramss = new
            //{
            //    user_auth = new
            //    {
            //        user_name = user_name,
            //        password = password,
            //        encryption = "PLAIN"
            //    },
            //    application = "SugarCRM RestAPI Example"
            //};

            //var JsonLoginString = JsonConvert.SerializeObject(paramss);

            //var rsClient = new RestClient("https://crm.orgbubble.com/service/v4_1/rest.php");
            //var rRequest = new RestRequest();
            //rRequest.AddParameter("method", "login");
            //rRequest.AddParameter("input_type", "JSON");
            //rRequest.AddParameter("response_type", "JSON");
            //rRequest.AddParameter("rest_data", JsonLoginString);

            //var rResponse = rsClient.Execute(rRequest);
            //var responseData = rResponse.Content;

            //var session = responseData.id;











            OBAPIResponse Response = new OBAPIResponse();
            var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();



            try
            {

                List<OrgBubble.general_users> obLst = new List<OrgBubble.general_users>();


                obLst = obDb.general_users.ToList();

                foreach (var oOBUser in obLst)
                {

                    //https://github.com/mattkol/SugarRestSharp/
                    var request = new SugarRestRequest(RequestType.BulkRead);
                    request.Options.MaxResult = 3;
                    
                    request.Options.QueryPredicates = new List<QueryPredicate>();

                    //request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Contact.em), QueryOperator.Equal, "Test"));
                    //request.Options.QueryPredicates.Add(new QueryPredicate("email1", QueryOperator.Equal, "sales.phone.info@example.edu"));
                    //request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Status), QueryOperator.Equal, "Assigned"));
                    //DateTime date = DateTime.Parse("07/02/2016");
                    //request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.DateEntered),
                    //                                              QueryOperator.Between, null, date.AddDays(-1),
                    //                                              DateTime.Now));


                    //request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Contact.Email), QueryOperator.Equal, "phone.kid.info@example.tw"));
                    //request.Options.QueryPredicates.Add(new QueryPredicate("email1", QueryOperator.Equal, oOBUser.email));
                    //request.Options.QueryPredicates.Add(new QueryPredicate("orgbubbleid_c", QueryOperator.Equal, oOBUser.id));

                    //request.Options.Query = String.Concat("contacts.email1='", oOBUser.email, "' or contacts.orgbubbleid_c ='", oOBUser.id,"'");
                    request.Options.Query = String.Concat("contacts.id IN (SELECT bean_id FROM email_addr_bean_rel eabr JOIN email_addresses ea ON (eabr.email_address_id = ea.id) WHERE bean_module = 'Contacts' AND ea.email_address_caps = '", "phone.kid.info@example.tw", "' AND eabr.deleted=0)");
                    //request.Options.QueryPredicates = new List<QueryPredicate>();

                    SugarRestResponse response = client.Execute<Contact>(request);


                }


                Response.success = obDb.Database.Exists() && ambDb.Database.Exists();
                Response.data = obLst;
                Response.message = "OB User found :" + obLst.Count();

                return Response;


            }
            catch (Exception e)
            {

                ErrorSignal.FromCurrentContext().Raise(e);
                return Response;
                throw;
            }








        }



        [Route("api/CRMOps/Tests")]
        [HttpPost]
        public OBAPIResponse Tests()
        {

            
            OBAPIResponse Response = new OBAPIResponse();


            var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();



            //Account info
            // Option 1 - Read by known type typeof(Account).
            var accountRequest = new SugarRestRequest(RequestType.ReadById);
            accountRequest.Parameter = "1d30bf4d-0f91-b46b-a389-5dd5c91680d1"; //5D Investments
            SugarRestResponse accountResponse = client.Execute<Account>(accountRequest);
            Account account = (Account)accountResponse.Data;



            // Option 2 - Read by known SugarCRM module name - "Contacts".
            var contactRequest = new SugarRestRequest("Contacts", RequestType.ReadById);
            contactRequest.Parameter = "16a50e00-8aba-c748-71a1-5dd5c947ec6a";
            SugarRestResponse contactRresponse = client.Execute(contactRequest);
            Contact contact = (Contact)contactRresponse.Data;



            var createAccountRequest = new SugarRestRequest("Accounts", RequestType.Create);
            SugarRestSharp.Models.Account actTest = new SugarRestSharp.Models.Account {
                Name = "Test from API",
                Website = "www.OrgBubble.com"
            };
            createAccountRequest.Parameter = actTest;

            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(SugarRestSharp.Models.Account.Name));
            selectFields.Add(nameof(SugarRestSharp.Models.Account.Website));

            createAccountRequest.Options.SelectFields = selectFields;
            SugarRestResponse response = client.Execute(createAccountRequest);

            Response.data = response;




            Response.success = true;
           
            Response.message = DateTime.Now.ToString();
            return Response;




        }








        // GET: api/CRMOps
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CRMOps/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CRMOps
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CRMOps/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CRMOps/5
        public void Delete(int id)
        {
        }
    }
}
