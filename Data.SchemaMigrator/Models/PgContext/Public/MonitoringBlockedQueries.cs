using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class MonitoringBlockedQueries
    {
        public int? Pid { get; set; }
        public int[] BlockedBy { get; set; }
        public string BlockedQuery { get; set; }
    }
}
