namespace OBSync.Models.OBDataSources
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OBSyncOLTP : DbContext
    {
        public OBSyncOLTP()
            : base("name=OBSyncOLTPConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
