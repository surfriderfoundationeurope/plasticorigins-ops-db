using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class River1
    {
        public River1()
        {
            Campaign1 = new HashSet<Campaign1>();
        }

        public decimal Cid { get; set; }
        public string CodeEntite { get; set; }
        public string Name { get; set; }
        public string Candidat { get; set; }
        public int Classe { get; set; }

        public virtual ICollection<Campaign1> Campaign1 { get; set; }
    }
}
