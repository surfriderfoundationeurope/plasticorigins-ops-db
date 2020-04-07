using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class Departement
    {
        public string Id { get; set; }
        public string NomDep { get; set; }
        public string InseeDep { get; set; }
        public string InseeReg { get; set; }
        public Geometry Geometry { get; set; }
    }
}
