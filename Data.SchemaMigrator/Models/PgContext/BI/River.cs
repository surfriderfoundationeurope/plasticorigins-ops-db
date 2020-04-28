using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class River
    {
        public string Name { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Length { get; set; }
        public long? TrashDetected { get; set; }
        public double? DistanceMonitored { get; set; }
        public Geometry Trace { get; set; }
    }
}
