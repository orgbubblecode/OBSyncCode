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
    
    public partial class am_projecttemplates_audit
    {
        public System.Guid id { get; set; }
        public System.Guid parent_id { get; set; }
        public Nullable<System.DateTime> date_created { get; set; }
        public string created_by { get; set; }
        public string field_name { get; set; }
        public string data_type { get; set; }
        public string before_value_string { get; set; }
        public string after_value_string { get; set; }
        public string before_value_text { get; set; }
        public string after_value_text { get; set; }
    }
}
