using Grand.Domain.Catalog;
using Grand.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Services.Catalog
{
    public partial class GalleryTemplateService : IGalleryTemplateService
    {
        private readonly IRepository<GalleryTemplate> _galleryTemplateRepository;

        public GalleryTemplateService(IRepository<GalleryTemplate> galleryTemplateRepository)
        {
            _galleryTemplateRepository = galleryTemplateRepository;
        }

        public virtual async Task<IList<GalleryTemplate>> GetAllGalleryTemplates()
        {
            var query = from pt in _galleryTemplateRepository.Table
                        orderby pt.DisplayOrder
                        select pt;
            return await Task.FromResult(query.ToList());
        }

        public virtual async Task<GalleryTemplate> GetGalleryTemplateById(string galleryTemplateId)
        {
            return await _galleryTemplateRepository.GetByIdAsync(galleryTemplateId);
        }
        public virtual async Task InsertGalleryTemplate(GalleryTemplate galleryTemplate)
        {
            await _galleryTemplateRepository.InsertAsync(galleryTemplate);
        }

        public virtual async Task UpdateGalleryTemplate(GalleryTemplate galleryTemplate)
        {
            await _galleryTemplateRepository.UpdateAsync(galleryTemplate);
        }

        public virtual async Task DeleteGalleryTemplate(GalleryTemplate galleryTemplate)
        {
            await _galleryTemplateRepository.DeleteAsync(galleryTemplate);
        }
    }
}