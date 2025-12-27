namespace Grand.Domain.Catalog
{
    public partial class GalleryTemplate : BaseEntity
    {
        public string Name { get; set; }
        public string ViewPath { get; set; }
        public int DisplayOrder { get; set; }
    }
}