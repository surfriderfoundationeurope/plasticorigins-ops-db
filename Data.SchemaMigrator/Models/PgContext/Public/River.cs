using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class River
    {
        public River()
        {
            TrajectoryPointRiver = new HashSet<TrajectoryPointRiver>();
            TrashRiver = new HashSet<TrashRiver>();
        }

        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Nature { get; set; }
        public int? Importance { get; set; }
        public string Origine { get; set; }
        public string CodeHydro { get; set; }
        public int? IdRefCountryFk { get; set; }
        public string Bras { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Country IdRefCountryFkNavigation { get; set; }
        public virtual ICollection<TrajectoryPointRiver> TrajectoryPointRiver { get; set; }
        public virtual ICollection<TrashRiver> TrashRiver { get; set; }
    }
}
