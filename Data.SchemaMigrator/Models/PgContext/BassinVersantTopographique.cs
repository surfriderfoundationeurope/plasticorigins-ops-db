using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext
{
    public partial class BassinVersantTopographique
    {
        public string Id { get; set; }
        public string CodeHydro { get; set; }
        public string Toponyme { get; set; }
        public string BassHydro { get; set; }
        public string DateCreat { get; set; }
        public string DateMaj { get; set; }
        public string DateApp { get; set; }
        public string DateConf { get; set; }
        public string Source { get; set; }
        public string IdSource { get; set; }
        public string PrecPlani { get; set; }
        public string SrcCoord { get; set; }
        public string Statut { get; set; }
        public string BFluvial { get; set; }
        public string Origine { get; set; }
        public string Comment { get; set; }
        public string CodeBh { get; set; }
        public string CodeCarth { get; set; }
        public string IdCEau { get; set; }
        public Geometry Geometry { get; set; }
    }
}
