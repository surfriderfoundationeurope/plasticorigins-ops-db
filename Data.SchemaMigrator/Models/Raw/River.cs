using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class River
    {
        public River()
        {
            Campaign = new HashSet<Campaign>();
        }

        public decimal Cid { get; set; }
        public string CodeEntite { get; set; }
        public string Name { get; set; }
        public string Candidat { get; set; }
        public int Classe { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
    }
}
