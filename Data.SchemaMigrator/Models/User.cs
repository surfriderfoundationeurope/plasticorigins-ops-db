using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public int? TotalDist { get; set; }
        public int? NumberOfCampaign { get; set; }
    }
}
