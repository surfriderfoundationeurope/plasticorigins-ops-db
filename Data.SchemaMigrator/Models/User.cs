using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class User
    {
        public User()
        {
            Campaigns_Campaign = new HashSet<Campaign_Campaign>();
            UserImagesForLabellings = new HashSet<ImagesForLabelling>();
            UserBoundingBoxesNavigation = new HashSet<BoundingBoxes>();
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

        public virtual ICollection<Campaign_Campaign> Campaigns_Campaign { get; set; }
        public virtual ICollection<ImagesForLabelling> UserImagesForLabellings { get; set; }
        public virtual ICollection<BoundingBoxes> UserBoundingBoxesNavigation { get; set; }
    }
}
