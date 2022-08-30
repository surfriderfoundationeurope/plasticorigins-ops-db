using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class TrajectoryPointRiver_Bi_Temp
    {
        public int Id { get; set; }
        public Guid IdRefTrajectoryPointFk { get; set; }
        public Guid IdRefCampaignFk { get; set; }
         public int IdRefSegmentFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public DateTime? Time { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
