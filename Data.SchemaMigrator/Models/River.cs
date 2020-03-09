using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class River
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? MeanDensityOfLitter { get; set; }
    }
}
