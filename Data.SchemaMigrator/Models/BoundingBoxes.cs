using System;

namespace Data.SchemaMigrator.Models
{
    public partial class BoundingBoxes
    {
        public BoundingBoxes()
        {
        }

        public Guid Id { get; set; }
        public Guid IdCreatorFk { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IdRefTrashTypeFk { get; set; }
        public Guid IdRefImagesForLabelling { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual ImagesForLabelling ImageForLabelling { get; set; }
    }
}