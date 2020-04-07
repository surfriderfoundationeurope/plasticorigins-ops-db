using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class ArrondissementDepartemental
    {
        public string Id { get; set; }
        public string InseeArr { get; set; }
        public string InseeDep { get; set; }
        public string InseeReg { get; set; }
        public Geometry Geometry { get; set; }
    }
}
