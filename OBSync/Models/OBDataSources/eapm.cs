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
    
    public partial class eapm
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> date_entered { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<System.Guid> modified_user_id { get; set; }
        public Nullable<System.Guid> created_by { get; set; }
        public string description { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.Guid> assigned_user_id { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public string application { get; set; }
        public string api_data { get; set; }
        public string consumer_key { get; set; }
        public string consumer_secret { get; set; }
        public string oauth_token { get; set; }
        public string oauth_secret { get; set; }
        public Nullable<bool> validated { get; set; }
    }
}
