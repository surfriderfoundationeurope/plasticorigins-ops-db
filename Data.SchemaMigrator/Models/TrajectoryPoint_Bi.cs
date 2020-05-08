using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class TrajectoryPoint_Bi
    {
        public Guid? Id { get; set; }
        public Geometry TheGeom { get; set; }
        public Guid? IdRefCampaignFk { get; set; }
        public double? Elevation { get; set; }
        public double? Distance { get; set; }
        public TimeSpan? TimeDiff { get; set; }
        public DateTime? Time { get; set; }
        public double? Speed { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
