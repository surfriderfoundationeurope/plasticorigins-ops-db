using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class ToponymieHydrographie
    {
        public string Id { get; set; }
        public string Classe { get; set; }
        public string Nature { get; set; }
        public string Graphie { get; set; }
        public string Source { get; set; }
        public string StatutTop { get; set; }
        public string DateTop { get; set; }
        public Geometry Geometry { get; set; }
    }
}
