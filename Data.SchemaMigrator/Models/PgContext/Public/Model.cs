using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class Model
    {
        public Model()
        {
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public int? Version { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Trash> Trash { get; set; }
    }
}
