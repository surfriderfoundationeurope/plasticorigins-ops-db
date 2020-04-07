using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class DetailHydrographique
    {
        public string Id { get; set; }
        public string Nature { get; set; }
        public string NatDetail { get; set; }
        public string Toponyme { get; set; }
        public string StatutTop { get; set; }
        public string Importance { get; set; }
        public string Etat { get; set; }
        public string DateCreat { get; set; }
        public string DateMaj { get; set; }
        public string DateApp { get; set; }
        public string DateConf { get; set; }
        public string Source { get; set; }
        public string IdSource { get; set; }
        public string PrecPlani { get; set; }
        public Geometry Geometry { get; set; }
    }
}
