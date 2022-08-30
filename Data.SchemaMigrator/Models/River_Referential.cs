using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class River_Referential
    {
        public River_Referential()
        {
            Segment = new HashSet<Segment_Referential>();
        }

        public int Id { get; set; }
         public string Code { get; set; }
        public Geometry TheGeom { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public int? Importance { get; set; }
        public DateTime? Createdon { get; set; }
        public virtual ICollection<Segment_Referential> Segment { get; set; }
    }
}
