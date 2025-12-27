using System;

namespace Grand.Domain.Catalog
{
    public partial class Gallery : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GalleryTemplateId { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}