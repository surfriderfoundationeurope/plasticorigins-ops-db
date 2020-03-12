using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class CampaignStaff
    {
        public Guid CampaignId { get; set; }
        public Guid UserId { get; set; }
        public bool? IsStaff { get; set; }
        public bool? HasBeenTrained { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual User User { get; set; }
    }
}
