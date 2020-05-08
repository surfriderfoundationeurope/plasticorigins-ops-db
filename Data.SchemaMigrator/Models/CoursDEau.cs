using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class CoursDEau
    {
        public string Id { get; set; }
        public string CodeHydro { get; set; }
        public string Toponyme { get; set; }
        public string StatutTop { get; set; }
        public string Importance { get; set; }
        public string DateCreat { get; set; }
        public string DateMaj { get; set; }
        public string DateApp { get; set; }
        public string DateConf { get; set; }
        public string Source { get; set; }
        public string IdSource { get; set; }
        public string Statut { get; set; }
        public string Maree { get; set; }
        public string Permanent { get; set; }
        public string Comment { get; set; }
        public Geometry Geometry { get; set; }
    }
}
