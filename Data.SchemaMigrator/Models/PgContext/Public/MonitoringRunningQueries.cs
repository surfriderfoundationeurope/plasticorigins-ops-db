using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class MonitoringRunningQueries
    {
        public int? Pid { get; set; }
        public string ApplicationName { get; set; }
        public DateTime? BackendStart { get; set; }
        public DateTime? QueryStart { get; set; }
        public string WaitEventType { get; set; }
        public string WaitEvent { get; set; }
        public string State { get; set; }
        public string Query { get; set; }
    }
}
