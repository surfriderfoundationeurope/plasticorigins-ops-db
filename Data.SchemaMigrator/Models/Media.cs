using System;
using System.Collections.Generic;
using System.Collections;

namespace Data.SchemaMigrator.Models
{
    public partial class Media
    {
        public Media()
        {
            Trash1 = new HashSet<Trash_Campaign>();
        }

        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string BlobUrl { get; set; }
        public string Createdby { get; set; }
        public BitArray Isdeleted { get; set; }
        public Guid? IdRefCampaignFk { get; set; }
        public Guid? IdRefTrajectoryPointsFk { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Campaign_Campaign IdRefCampaignFkNavigation { get; set; }
        public virtual TrajectoryPoint_Campaign IdRefTrajectoryPointsFkNavigation { get; set; }
        public virtual ICollection<Trash_Campaign> Trash1 { get; set; }
    }
}
