using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class CampaignImageAssoc
    {
        public Guid CampaignId { get; set; }
        public Guid ImageId { get; set; }

        public virtual Campaign1 Campaign { get; set; }
        public virtual Images Image { get; set; }
    }
}
