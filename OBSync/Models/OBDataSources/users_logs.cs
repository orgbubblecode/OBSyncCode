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
    
    public partial class users_logs
    {
        public long id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string type { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string ip { get; set; }
        public Nullable<int> @public { get; set; }
    
        public virtual user user { get; set; }
    }
}
