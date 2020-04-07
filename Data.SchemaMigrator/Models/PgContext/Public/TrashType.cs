using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class TrashType
    {
        public TrashType()
        {
            Trash = new HashSet<Trash>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Trash> Trash { get; set; }
    }
}
