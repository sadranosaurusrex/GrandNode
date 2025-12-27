namespace Grand.Domain.Catalog
{
    /// <summary>
    /// Represents a gallery picture mapping
    /// </summary>
    public partial class GalleryPicture : BaseEntity
    {
        /// <summary>
        /// Gets or sets the gallery identifier
        /// </summary>
        public string GalleryId { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public string PictureId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the alt attribute for img HTML element
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// Gets or sets the title attribute for img HTML element
        /// </summary>
        public string TitleAttribute { get; set; }
    }
}