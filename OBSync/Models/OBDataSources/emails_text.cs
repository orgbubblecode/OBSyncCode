//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSync.Models.OBDataSources
{
    using System;
    using System.Collections.Generic;
    
    public partial class emails_text
    {
        public System.Guid email_id { get; set; }
        public string from_addr { get; set; }
        public string reply_to_addr { get; set; }
        public string to_addrs { get; set; }
        public string cc_addrs { get; set; }
        public string bcc_addrs { get; set; }
        public string description { get; set; }
        public string description_html { get; set; }
        public string raw_source { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
