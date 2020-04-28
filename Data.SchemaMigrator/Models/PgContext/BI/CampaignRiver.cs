using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class CampaignRiver
    {
        public Guid? IdRefCampaignFk { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Distance { get; set; }
        public string RiverName { get; set; }
    }
}
