using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.CRM.ESPOCRM
{
    public class Account
    {
        public string name { get; set; }
        public  string accountSystem { get; set; }
        public string accountTitle { get; set; }
        public string emailAddress { get; set; }
        public string createdAt { get; set; }

        public string accountType { get; set; }
        public string type { get; set; }
    }
}
