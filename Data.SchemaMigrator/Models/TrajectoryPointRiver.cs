using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class TrajectoryPointRiver
    {
        public int Id { get; set; }
        public Guid IdRefTrajectoryPointFk { get; set; }
        public Guid IdRefCampaignFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public Geometry TrajectoryPointTheGeom { get; set; }
        public Geometry RiverTheGeom { get; set; }
        public Geometry ClosestPointTheGeom { get; set; }
        public int? Importance { get; set; }
        public string RiverName { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
