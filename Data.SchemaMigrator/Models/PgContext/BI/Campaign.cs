using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class Campaign
    {
        public int Id { get; set; }
        public string IdRefCampaignFk { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Geometry StartPoint { get; set; }
        public Geometry EndPoint { get; set; }
        public double? TotalDistance { get; set; }
        public int? AvgSpeed { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? StartPointDistanceSea { get; set; }
        public double? EndPointDistanceSea { get; set; }
        public int? TrashCount { get; set; }
        public double? DistanceStartEnd { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
