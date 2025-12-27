using Grand.Core;
using Grand.Domain;
using Grand.Domain.Catalog;
using System.Threading.Tasks;

namespace Grand.Services.Catalog
{
    public partial interface IGalleryService
    {
        Task<Gallery> GetGalleryById(string galleryId);
        Task<IPagedList<Gallery>> GetAllGalleries(string galleryName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);
        Task InsertGallery(Gallery gallery);
        Task UpdateGallery(Gallery gallery);
        Task DeleteGallery(Gallery gallery);
    }
}