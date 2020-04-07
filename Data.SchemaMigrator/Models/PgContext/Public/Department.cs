using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class Department
    {
        public Department()
        {
            Municipality = new HashSet<Municipality>();
        }

        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IdSource { get; set; }
        public int? IdRefStateFk { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual State IdRefStateFkNavigation { get; set; }
        public virtual ICollection<Municipality> Municipality { get; set; }
    }
}
