using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Epci
    {
        public string Id { get; set; }
        public string CodeEpci { get; set; }
        public string NomEpci { get; set; }
        public string TypeEpci { get; set; }
        public Geometry Geometry { get; set; }
    }
}
