using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class LimitsLandSea
    {
        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IdSource { get; set; }
        public string Nature { get; set; }
        public string Origine { get; set; }
        public string CodeHydro { get; set; }
        public int? IdRefCountryFk { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Country IdRefCountryFkNavigation { get; set; }
    }
}
