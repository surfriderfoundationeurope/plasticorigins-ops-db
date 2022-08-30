using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Segment_Bi_Temp
    {
        public int Id { get; set; }
        public int? Importance { get; set; }
        public double? CountTrash { get; set; }
        public double? DistanceMonitored { get; set; }
        public Geometry TheGeomMonitored { get; set; }
        public decimal? TrashPerKm { get; set; }
        public int? NbCampaign { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
