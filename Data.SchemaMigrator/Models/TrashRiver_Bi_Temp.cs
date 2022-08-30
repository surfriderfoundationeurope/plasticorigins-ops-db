using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class TrashRiver_Bi_Temp
    {
        public int Id { get; set; }
        public Guid IdRefTrashFk { get; set; }
        public Guid IdRefCampaignFk { get; set; }
         public int IdRefSegmentFk { get; set; }
        public int IdRefRiverFk { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
