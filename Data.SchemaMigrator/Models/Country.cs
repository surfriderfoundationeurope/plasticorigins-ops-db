using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Country
    {
        public Country()
        {
            LimitsLandSea = new HashSet<LimitsLandSea>();
            Segment = new HashSet<Segment_Referential>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? Createdon { get; set; }
        public string FeatureCollection { get; set; }

        public virtual ICollection<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual ICollection<Segment_Referential> Segment { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
