using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class Campaign
    {
        public Campaign()
        {
            Image = new HashSet<Image>();
            TrajectoryPoint = new HashSet<TrajectoryPoint>();
            Trash = new HashSet<Trash>();
        }

        public Guid Id { get; set; }
        public string Locomotion { get; set; }
        public bool? Isaidriven { get; set; }
        public string Remark { get; set; }
        public Guid? IdRefUserFk { get; set; }
        public string Riverside { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public TimeSpan? Duration { get; set; }
        public Geometry StartingPointTheGeom { get; set; }
        public Geometry EndingPointTheGeom { get; set; }
        public double? DistanceStartEnd { get; set; }
        public double? TotalDistance { get; set; }
        public double? AvgSpeed { get; set; }
        public string File { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual UserCampaign IdRefUserFkNavigation { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<TrajectoryPoint> TrajectoryPoint { get; set; }
        public virtual ICollection<Trash> Trash { get; set; }
    }
}
