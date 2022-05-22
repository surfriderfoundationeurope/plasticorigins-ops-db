using System;
using System.Collections.Generic;

namespace Data.SchemaMigrator.Models
{
    public partial class TrashType
    {
        public TrashType()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
