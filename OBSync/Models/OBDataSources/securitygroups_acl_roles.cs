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
    
    public partial class securitygroups_acl_roles
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> securitygroup_id { get; set; }
        public Nullable<System.Guid> role_id { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
