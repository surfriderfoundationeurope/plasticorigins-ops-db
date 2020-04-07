using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class Commune
    {
        public string Id { get; set; }
        public string Statut { get; set; }
        public string InseeCom { get; set; }
        public string NomCom { get; set; }
        public string InseeArr { get; set; }
        public string NomDep { get; set; }
        public string InseeDep { get; set; }
        public string NomReg { get; set; }
        public string InseeReg { get; set; }
        public string CodeEpci { get; set; }
        public string NomComM { get; set; }
        public string Population { get; set; }
        public Geometry Geometry { get; set; }
    }
}
