using System;
using System.Collections.Generic;
using System.Collections;

namespace Data.SchemaMigrator.Models.PgContext.Campaign
{
    public partial class Image
    {
        public Image()
        {
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Blobname { get; set; }
        public string Containerurl { get; set; }
        public string Createdby { get; set; }
        public BitArray Isdeleted { get; set; }
        public int Version { get; set; }
        public Guid? IdRefCampaignFk { get; set; }
        public Guid? IdRefTrajectoryPointsFk { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Campaign IdRefCampaignFkNavigation { get; set; }
        public virtual TrajectoryPoint IdRefTrajectoryPointsFkNavigation { get; set; }
        public virtual ICollection<Trash> Trash { get; set; }
    }
}
