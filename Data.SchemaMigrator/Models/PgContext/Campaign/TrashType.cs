using System;
using System.Collections.Generic;
using Data.SchemaMigrator.Models.PgContext.Label;

namespace Data.SchemaMigrator.Models.PgContext.Campaign
{
    public partial class TrashType
    {
        public TrashType()
        {
            Trash = new HashSet<Trash>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Trash> Trash { get; set; }
        public virtual ICollection<BoundingBoxes> TrashTypeBoundingBoxesNavigation { get; set; }
    }
}
