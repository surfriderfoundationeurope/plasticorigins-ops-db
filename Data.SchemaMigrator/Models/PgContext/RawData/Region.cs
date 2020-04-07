using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class Region
    {
        public string Id { get; set; }
        public string NomReg { get; set; }
        public string InseeReg { get; set; }
        public Geometry Geometry { get; set; }
    }
}
