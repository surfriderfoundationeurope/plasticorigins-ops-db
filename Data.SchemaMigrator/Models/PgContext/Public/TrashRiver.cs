using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class TrashRiver
    {
        public int Id { get; set; }
        public Guid IdRefTrashFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public Geometry TrashTheGeom { get; set; }
        public Geometry RiverTheGeom { get; set; }
        public Geometry ClosestPointTheGeom { get; set; }
        public double DistanceRiverTrash { get; set; }
        public Geometry ProjectionTrashRiverTheGeom { get; set; }
        public int? Importance { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual River IdRefRiverFkNavigation { get; set; }
        public virtual Trash IdRefTrashFkNavigation { get; set; }
    }
}
