using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class User1
    {
        public User1()
        {
            Campaign1 = new HashSet<Campaign1>();
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

        public virtual ICollection<Campaign1> Campaign1 { get; set; }
        public virtual ICollection<CampaignStaff> CampaignStaff { get; set; }
    }
}
