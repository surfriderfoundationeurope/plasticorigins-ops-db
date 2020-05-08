using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Trash_Campaign
    {
        public Guid Id { get; set; }
        public Guid IdRefCampaignFk { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Elevation { get; set; }
        public int IdRefTrashTypeFk { get; set; }
        public double? Precision { get; set; }
        public Guid? IdRefModelFk { get; set; }
        public string BrandType { get; set; }
        public Guid? IdRefImageFk { get; set; }
        public DateTime? Time { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Campaign_Campaign IdRefCampaignFkNavigation { get; set; }
        public virtual Image IdRefImageFkNavigation { get; set; }
        public virtual AiModel IdRefModelFkNavigation { get; set; }
        public virtual TrashType IdRefTrashTypeFkNavigation { get; set; }
    }
}
