using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Data.SchemaMigrator.Models
{
    public partial class Trash_Bi
    {
        public Guid Id { get; set; }
        public Guid IdRefCampaignFk { get; set; }
        public Geometry TheGeom { get; set; }
        public double? Elevation { get; set; }
        public int IdRefTrashTypeFk { get; set; }
        public double? Precision { get; set; }
        public Guid? IdRefModelFk { get; set; }
        public Guid? IdRefImageFk { get; set; }
        public DateTime? Time { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string MunicipalityName { get; set; }
        public string MunicipalityCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
