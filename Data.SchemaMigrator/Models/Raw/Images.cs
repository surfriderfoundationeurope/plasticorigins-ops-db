using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class Images
    {
        public Images()
        {
            CampaignImageAssoc = new HashSet<CampaignImageAssoc>();
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string BlobName { get; set; }
        public string ContainerUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<CampaignImageAssoc> CampaignImageAssoc { get; set; }
        public virtual ICollection<Trash> Trash { get; set; }
    }
}
