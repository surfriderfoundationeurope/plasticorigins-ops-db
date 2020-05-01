using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class Logs
    {
        public Guid Id { get; set; }
        public DateTime InitiatedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public double? ElapsedTime { get; set; }
        public string Status { get; set; }
    }
}
