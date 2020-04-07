using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class SurfaceHydrographique
    {
        public string Id { get; set; }
        public string CodeHydro { get; set; }
        public string CodePays { get; set; }
        public string Nature { get; set; }
        public string PosSol { get; set; }
        public string Etat { get; set; }
        public string DateCreat { get; set; }
        public string DateMaj { get; set; }
        public string DateApp { get; set; }
        public string DateConf { get; set; }
        public string Source { get; set; }
        public string IdSource { get; set; }
        public string PrecPlani { get; set; }
        public string PrecAlti { get; set; }
        public string SrcCoord { get; set; }
        public string SrcAlti { get; set; }
        public string Statut { get; set; }
        public string Persistanc { get; set; }
        public string Salinite { get; set; }
        public string Origine { get; set; }
        public string Comment { get; set; }
        public string IdPEau { get; set; }
        public string IdCEau { get; set; }
        public string IdEntTr { get; set; }
        public string NomPEau { get; set; }
        public string NomCEau { get; set; }
        public string NomEntTr { get; set; }
        public Geometry Geometry { get; set; }
    }
}
