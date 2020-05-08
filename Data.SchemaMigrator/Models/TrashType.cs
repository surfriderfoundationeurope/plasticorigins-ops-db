using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class TrashType
    {
        public TrashType()
        {
            Trash = new HashSet<Trash_Bi>();
            Trash1 = new HashSet<Trash_Campaign>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Trash_Bi> Trash { get; set; }
        public virtual ICollection<Trash_Campaign> Trash1 { get; set; }
    }
}
