using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class CampaignRiver
    {
        public int Id { get; set; }
        public Guid? IdRefCampaignFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public decimal? Distance { get; set; }
        public int? TrashCount { get; set; }
        public decimal? TrashPerKm { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
        public string FeatureCollection { get; set; }
    }
}
