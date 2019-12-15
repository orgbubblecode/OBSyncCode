using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSync.Models
{
    public class OBAPIResponse
    {

        public bool success { get; set; } = false;
        public string message { get; set; } = "";
        public string referenceID { get; set; } = "";
        public object data { get; set; } 


    }
}