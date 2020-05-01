using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Campaign
{
    public partial class Model
    {
        public Model()
        {
            Campaign = new HashSet<Campaign>();
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public int? Version { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
        public virtual ICollection<Trash> Trash { get; set; }
    }
}
