using System;
using System.Collections.Generic;
using Data.SchemaMigrator.Models.PgContext.Campaign;

namespace Data.SchemaMigrator.Models.PgContext.Label
{
    public partial class ImagesForLabelling
    {
        public ImagesForLabelling()
        {
        }

        public Guid Id { get; set; }
        public Guid IdCreatorFk { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Filename { get; set; }
        public string View { get; set; }
        public string ImageQuality { get; set; }
        public string Context { get; set; }
        public string ContainerUrl { get; set; }
        public string BlobName { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<BoundingBoxes> ImagesForLabellingBoundingBoxesNavigation { get; set; }

    }
}
