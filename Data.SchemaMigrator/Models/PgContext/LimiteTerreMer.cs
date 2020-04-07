using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class LimiteTerreMer
    {
        public string Id { get; set; }
        public string CodeHydro { get; set; }
        public string CodePays { get; set; }
        public string TypeLimit { get; set; }
        public string Niveau { get; set; }
        public string DateCreat { get; set; }
        public string DateMaj { get; set; }
        public string DateApp { get; set; }
        public string DateConf { get; set; }
        public string Source { get; set; }
        public string IdSource { get; set; }
        public string PrecPlani { get; set; }
        public string SrcCoord { get; set; }
        public string Statut { get; set; }
        public string Origine { get; set; }
        public string Comment { get; set; }
        public Geometry Geometry { get; set; }
    }
}
