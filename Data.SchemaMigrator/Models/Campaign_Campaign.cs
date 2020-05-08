using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class Campaign_Campaign
    {
        public Campaign_Campaign()
        {
            Image = new HashSet<Media>();
            TrajectoryPoints_Campaign = new HashSet<TrajectoryPoint_Campaign>();
            Trash1 = new HashSet<Trash_Campaign>();
            Bi_Logs = new HashSet<Bi_Log>();
            Etl_Logs = new HashSet<Etl_Log>();
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

        public virtual AiModel IdRefModelFkNavigation { get; set; }
        public virtual User IdRefUserFkNavigation { get; set; }
        public virtual ICollection<Media> Image { get; set; }
        public virtual ICollection<TrajectoryPoint_Campaign> TrajectoryPoints_Campaign { get; set; }
        public virtual ICollection<Trash_Campaign> Trash1 { get; set; }
        public virtual ICollection<Bi_Log> Bi_Logs { get; set; }
        public virtual ICollection<Etl_Log> Etl_Logs { get; set; }
    }
}
