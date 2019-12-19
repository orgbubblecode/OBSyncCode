using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SugarRestSharp;

namespace OBSync.Models.Helpers
{
    public class SuiteCRM
    {

        public static SugarRestClient GetSuiteCRMClient()
        {

            // sugarCRM project site: 
            string sugarCrmUrl = "https://crm.orgbubble.com/service/v4_1/rest.php";
            string sugarCrmUsername = "obapiuser";
            string sugarCrmPassword = "Th34piUs3770";

            return new SugarRestClient(sugarCrmUrl, sugarCrmUsername, sugarCrmPassword);


        }

    }
}