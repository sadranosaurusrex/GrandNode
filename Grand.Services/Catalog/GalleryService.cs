using Grand.Core;
using Grand.Domain;
using Grand.Domain.Catalog;
using Grand.Domain.Data;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Services.Catalog
{
    public partial class GalleryService : IGalleryService
    {
        private readonly IRepository<Gallery> _galleryRepository;

        public GalleryService(IRepository<Gallery> galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public virtual async Task<Gallery> GetGalleryById(string galleryId)
        {
            return await _galleryRepository.GetByIdAsync(galleryId);
        }

        public virtual async Task<IPagedList<Gallery>> GetAllGalleries(string galleryName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = from g in _galleryRepository.Table
                        select g;

            if (!showHidden)
                query = query.Where(g => g.Published);

            if (!string.IsNullOrWhiteSpace(galleryName))
                query = query.Where(g => g.Name != null && g.Name.ToLower().Contains(galleryName.ToLower()));

            query = query.OrderBy(g => g.Name);

            return await Task.FromResult(new PagedList<Gallery>(query, pageIndex, pageSize));
        }

        public virtual async Task InsertGallery(Gallery gallery)
        {
            gallery.CreatedOnUtc = DateTime.UtcNow;
            gallery.UpdatedOnUtc = DateTime.UtcNow;
            await _galleryRepository.InsertAsync(gallery);
        }

        public virtual async Task UpdateGallery(Gallery gallery)
        {
            gallery.UpdatedOnUtc = DateTime.UtcNow;
            await _galleryRepository.UpdateAsync(gallery);
        }

        public virtual async Task DeleteGallery(Gallery gallery)
        {
            await _galleryRepository.DeleteAsync(gallery);
        }
    }
}