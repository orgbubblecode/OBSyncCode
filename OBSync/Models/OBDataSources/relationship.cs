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
    
    public partial class relationship
    {
        public System.Guid id { get; set; }
        public string relationship_name { get; set; }
        public string lhs_module { get; set; }
        public string lhs_table { get; set; }
        public string lhs_key { get; set; }
        public string rhs_module { get; set; }
        public string rhs_table { get; set; }
        public string rhs_key { get; set; }
        public string join_table { get; set; }
        public string join_key_lhs { get; set; }
        public string join_key_rhs { get; set; }
        public string relationship_type { get; set; }
        public string relationship_role_column { get; set; }
        public string relationship_role_column_value { get; set; }
        public Nullable<bool> reverse { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
