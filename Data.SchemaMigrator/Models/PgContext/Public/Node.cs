using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class Node
    {
        public Geometry TheGeom { get; set; }
        public string Id { get; set; }
        public string CodeHydro { get; set; }
        public string CodePays { get; set; }
        public string Categorie { get; set; }
        public string Toponyme { get; set; }
        public string StatutTop { get; set; }
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
        public string Comment { get; set; }
        public string IdCeAmon { get; set; }
        public string IdCeAval { get; set; }
        public Geometry Geometry { get; set; }
    }
}
