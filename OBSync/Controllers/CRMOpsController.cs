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




namespace OBSync.Controllers
{
    public class CRMOpsController : ApiController
    {
        private AllMyBioDbEntities ambDb = new AllMyBioDbEntities();
        private OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();


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


                Response.success = obDb.Database.Exists() && ambDb.Database.Exists();
                Response.data = list;
                Response.message = "hello";


                return Response;

            }
            catch (Exception)
            {

                return Response;

                throw;
            }

            


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
