using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Basin
    {
        public string BasinId { get; set; }
        public int FecCount { get; set; }
        public string BasinName { get; set; }
        public string CountryCode { get; set; }
        public Geometry TheGeom { get; set; }
        public string FeatureCollection { get; set; }
        public double AreaSquareKm { get; set; }
        public Geometry TheGeomBB { get; set; }
        
    }
}
