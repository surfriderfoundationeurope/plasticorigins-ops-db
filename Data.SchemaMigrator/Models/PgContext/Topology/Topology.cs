using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models.PgContext.Topology
{
    public partial class Topology
    {
        public Topology()
        {
            Layer = new HashSet<Layer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Srid { get; set; }
        public double Precision { get; set; }
        public bool Hasz { get; set; }

        public virtual ICollection<Layer> Layer { get; set; }
    }
}
