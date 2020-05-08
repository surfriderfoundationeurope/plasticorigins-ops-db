using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class AiModel
    {
        public AiModel()
        {
            Campaigns_Campaign = new HashSet<Campaign_Campaign>();
            Trash1 = new HashSet<Trash_Campaign>();
        }

        public Guid Id { get; set; }
        public int? Version { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Campaign_Campaign> Campaigns_Campaign { get; set; }
        public virtual ICollection<Trash_Campaign> Trash1 { get; set; }
    }
}
