﻿using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class TrajectoryPoint_Campaign
    {
        public TrajectoryPoint_Campaign()
        {
            Image = new HashSet<Media>();
        }

        public Guid Id { get; set; }
        public Geometry TheGeom { get; set; }
        public Guid IdRefCampaignFk { get; set; }
        public double? Elevation { get; set; }
        public DateTime? Time { get; set; }
        public double? Speed { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual Campaign_Campaign IdRefCampaignFkNavigation { get; set; }
        public virtual ICollection<Media> Image { get; set; }
    }
}
