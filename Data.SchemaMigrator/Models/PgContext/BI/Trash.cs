using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class Trash
    {
        public Guid Id { get; set; }
        public string[] IdRefCampaignFk { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Elevation { get; set; }
        public int IdRefTrashTypeFk { get; set; }
        public double? Precision { get; set; }
        public string[] IdRefModelFk { get; set; }
        public string BrandType { get; set; }
        public string[] IdRefImageFk { get; set; }
        public DateTime[] Time { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
