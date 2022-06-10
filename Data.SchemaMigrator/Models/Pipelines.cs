using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Pipelines
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public Boolean? CampaignHasBeenComputed { get; set; }
        public Boolean? RiverHasBeenComputed { get; set; }
    }
}
