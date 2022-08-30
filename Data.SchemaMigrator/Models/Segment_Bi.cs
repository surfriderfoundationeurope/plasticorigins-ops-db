using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Segment_Bi
    {
        public int Id { get; set; }
        public int? Importance { get; set; }
        public double? CountTrash { get; set; }
        public double? DistanceMonitored { get; set; }
        public decimal? TrashPerKm { get; set; }
        public int? NbCampaign { get; set; }
        public double? CountTrashRiver { get; set; }
        public double? DistanceMonitoredRiver { get; set; }
        public decimal? TrashPerKmRiver { get; set; }
        public int? NbCampaignRiver { get; set; }
        public Geometry TheGeom { get; set; }
        public Geometry TheGeomMonitored { get; set; }
        public string FeatureCollection { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
