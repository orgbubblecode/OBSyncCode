using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NameParser;


namespace OBSync.Models.Helpers
{
    public class Utilities
    {

        public static HumanName  NameObject(string FullName)
        {

            var oName = new HumanName(FullName);
            return oName;

        }

    }
}