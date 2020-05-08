using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class User
    {
        public User()
        {
            Campaign1 = new HashSet<Campaign_Campaign>();
        }

        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool Emailconfirmed { get; set; }
        public string Passwordhash { get; set; }
        public DateTime? Yearofbirth { get; set; }
        public string Experience { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Campaign_Campaign> Campaign1 { get; set; }
    }
}
