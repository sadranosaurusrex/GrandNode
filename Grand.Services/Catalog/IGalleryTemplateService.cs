using Grand.Domain.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Services.Catalog
{
    public partial interface IGalleryTemplateService
    {
        Task<IList<GalleryTemplate>> GetAllGalleryTemplates();
        Task<GalleryTemplate> GetGalleryTemplateById(string galleryTemplateId);
        Task InsertGalleryTemplate(GalleryTemplate galleryTemplate);
        Task UpdateGalleryTemplate(GalleryTemplate galleryTemplate);
        Task DeleteGalleryTemplate(GalleryTemplate galleryTemplate);
    }
}