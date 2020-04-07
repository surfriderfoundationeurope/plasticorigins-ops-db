using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class Traces
    {
        public double? Elevation { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Time { get; set; }
        public string File { get; set; }
        public double? CampaignId { get; set; }
        public string Locomotion { get; set; }
        public string Method { get; set; }
        public string Riverside { get; set; }
        public string River { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
