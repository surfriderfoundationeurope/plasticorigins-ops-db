using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class User
    {
        public User()
        {
            Campaign = new HashSet<Campaign>();
            CampaignStaff = new HashSet<CampaignStaff>();
        }

        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? YearOfBirth { get; set; }
        public string Experience { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
        public virtual ICollection<CampaignStaff> CampaignStaff { get; set; }
    }
}
