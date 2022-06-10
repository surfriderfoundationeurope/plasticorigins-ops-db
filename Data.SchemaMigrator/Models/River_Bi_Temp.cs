using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class River_Bi_Temp
    {
        public string Name { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Length { get; set; }
        public double? CountUniqueTrash { get; set; }
        public double? CountTrash { get; set; }
        public double? DistanceMonitored { get; set; }
        public Geometry TheGeomMonitored { get; set; }
        public decimal? TrashPerKm { get; set; }
        public int Id { get; set; }
    }
}
