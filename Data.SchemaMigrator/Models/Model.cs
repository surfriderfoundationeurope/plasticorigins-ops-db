using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class AiModel
    {
        public AiModel()
        {
            Campaign1 = new HashSet<Campaign_Campaign>();
            Trash1 = new HashSet<Trash_Campaign>();
        }

        public Guid Id { get; set; }
        public int? Version { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Campaign_Campaign> Campaign1 { get; set; }
        public virtual ICollection<Trash_Campaign> Trash1 { get; set; }
    }
}
