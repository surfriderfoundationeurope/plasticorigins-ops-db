using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Campaign_Bi_Temp
    {
        public Guid Id { get; set; }
        public string Locomotion { get; set; }
        public bool? Isaidriven { get; set; }
        public string Remark { get; set; }
        public Guid? IdRefUserFk { get; set; }
        public string Riverside { get; set; }
        public Guid? IdRefModelFk { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Geometry StartPoint { get; set; }
        public Geometry EndPoint { get; set; }
        public double? Distance { get; set; }
        public int? AvgSpeed { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? StartPointDistanceSea { get; set; }
        public double? EndPointDistanceSea { get; set; }
        public int? TrashCount { get; set; }
        public decimal? TrashPerKm { get; set; }
        public Geometry TheGeom { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
