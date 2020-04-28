using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class TrashRiver
    {
        public int Id { get; set; }
        public Guid IdRefTrashFk { get; set; }
        public Guid IdRefCampaignFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public Geometry TrashTheGeom { get; set; }
        public Geometry RiverTheGeom { get; set; }
        public Geometry ClosestPointTheGeom { get; set; }
        public double DistanceRiverTrash { get; set; }
        public Geometry ProjectionTrashRiverTheGeom { get; set; }
        public int? Importance { get; set; }
        public string RiverName { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
