using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class Etl_Log
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public Guid MediaId { get; set; }
        public string MediaName { get; set; }
        public DateTime InitiatedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public double? ElapsedTime { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string ScriptVersion { get; set; }
        public virtual Campaign_Campaign EtlLogs_Campaign_CampaignFKNavigation { get; set; }

    }
}