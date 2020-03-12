using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Bi
{
    public partial class Campaign
    {
        public Guid Id { get; set; }
        public int? CampaignStartSeaDist { get; set; }
        public int? CampaignEndSeaDist { get; set; }
        public int? TotalDist { get; set; }
        public int? TotalLitter { get; set; }
        public int? LitterDensity { get; set; }
        public int? TotalUnknow { get; set; }
        public int? TotalUnknow10 { get; set; }
        public int? TotalCommonHouseholdItems { get; set; }
        public int? TotalDrinkingBottles { get; set; }
        public int? TotalFoodPackaging { get; set; }
        public int? TotalAgriculturalWaste { get; set; }
        public int? TotalIndustrialOrConstructionDebris { get; set; }
        public int? TotalFishingAndHunting { get; set; }
        public int? TotalBottles { get; set; }
        public int? TotalFragments { get; set; }
        public int? TotalOthers { get; set; }
    }
}
