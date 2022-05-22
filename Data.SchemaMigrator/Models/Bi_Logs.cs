using System;

namespace Data.SchemaMigrator.Models
{
    public partial class Bi_Log
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime InitiatedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public double? ElapsedTime { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string ScriptVersion { get; set; }
        public string FailedStep { get; set; } 

    }
}