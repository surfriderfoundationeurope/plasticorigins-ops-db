using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class ChefLieu
    {
        public string Id { get; set; }
        public string NomChf { get; set; }
        public string Statut { get; set; }
        public string InseeCom { get; set; }
        public Geometry Geometry { get; set; }
    }
}
