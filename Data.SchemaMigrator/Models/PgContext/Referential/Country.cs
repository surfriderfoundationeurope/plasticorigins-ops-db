using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Referential
{
    public partial class Country
    {
        public Country()
        {
            LimitsLandSea = new HashSet<LimitsLandSea>();
            River = new HashSet<River>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual ICollection<River> River { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
