using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Referential
{
    public partial class Municipality
    {
        public int Id { get; set; }
        public Geometry TheGeom { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IdSource { get; set; }
        public int? IdRefDepartmentFk { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Department IdRefDepartmentFkNavigation { get; set; }
    }
}
