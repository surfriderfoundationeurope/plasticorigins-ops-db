using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class Trash
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public Guid TrashTypeId { get; set; }
        public double? Precision { get; set; }
        public decimal? AiVersion { get; set; }
        public string BrandType { get; set; }
        public Guid? RelatedImageId { get; set; }
        public decimal? Aiversion1 { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Images RelatedImage { get; set; }
        public virtual TrashType TrashType { get; set; }
    }
}
