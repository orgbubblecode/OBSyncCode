using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Common
{
    public class LocalConfig
    {

        private string _file;

        public int lastAMBImported = 0;

        public LocalConfig()
        {
            _file = "D:\\WebProjects\\orgbubble.com\\CODE\\OBSync\\OBSyncTool\\localconfigfile.json";

        }




    }
}
