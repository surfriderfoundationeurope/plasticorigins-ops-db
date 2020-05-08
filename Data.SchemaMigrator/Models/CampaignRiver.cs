using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class CampaignRiver
    {
        public int Id { get; set; }
        public Guid? IdRefCampaignFk { get; set; }
        public string RiverName { get; set; }
        public decimal? Distance { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
