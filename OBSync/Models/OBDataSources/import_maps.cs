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
    
    public partial class import_maps
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public string enclosure { get; set; }
        public string delimiter { get; set; }
        public string module { get; set; }
        public string content { get; set; }
        public string default_values { get; set; }
        public Nullable<bool> has_header { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> date_entered { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<System.Guid> assigned_user_id { get; set; }
        public string is_published { get; set; }
    }
}
