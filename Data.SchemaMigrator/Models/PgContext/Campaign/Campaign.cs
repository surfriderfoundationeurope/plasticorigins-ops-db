using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Campaign
{
    public partial class Campaign
    {
        public Campaign()
        {
            Image = new HashSet<Image>();
            TrajectoryPoint = new HashSet<TrajectoryPoint>();
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public string Locomotion { get; set; }
        public bool? Isaidriven { get; set; }
        public string Remark { get; set; }
        public Guid? IdRefUserFk { get; set; }
        public string Riverside { get; set; }
        public string ContainerUrl { get; set; }
        public string BlobName { get; set; }
        public Guid? IdRefModelFk { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Model IdRefModelFkNavigation { get; set; }
        public virtual User IdRefUserFkNavigation { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<TrajectoryPoint> TrajectoryPoint { get; set; }
        public virtual ICollection<Trash> Trash { get; set; }
    }
}
