using ApiCallerApp;
using OBSyncTool.Busines.CRM.ESPOCRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OBSyncTool.Busines.AMB.API;
using static OBSyncTool.Busines.AMB.Model_.User;

namespace OBSyncTool.Busines.AMB.Jobs
{
    public  class InContact
    {

        public async static Task<bool> SyncAMBAccountsToInContact()
        {

            string configFilePath = "D:\\WebProjects\\orgbubble.com\\CODE\\OBSync\\OBSyncTool\\localconfigfile_incontact.json";
            AppConfig config = AppConfig.Load(configFilePath);


            int pageSize = 35;
            int startPage = 1;
            bool hasMoreData = true;
            var SearchParams = new SearhByColumnSearchArray[] {
                new SearhByColumnSearchArray() { columnLogic = "=", columnName = "status", columnValue = "1" },
                new SearhByColumnSearchArray() { columnLogic = ">", columnName = "user_id", columnValue = config.LastAMBIDRead }
            };
            API _api = new OBSyncTool.Busines.AMB.API();  
            string searchPath = "/users/search_by_column.php?orAnd=And&pageno={0}&pagesize={1}";




        }

    }
}
