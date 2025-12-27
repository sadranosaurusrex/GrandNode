using Grand.Core.Mapper;
using Grand.Web.Areas.Admin.Models.Catalog;

namespace Grand.Web.Areas.Admin.Extensions.Mapping
{
    public static class GalleryMappingExtensions
    {
        public static GalleryModel ToModel(this Grand.Domain.Catalog.Gallery entity)
        {
            return entity.MapTo<Grand.Domain.Catalog.Gallery, GalleryModel>();
        }

        public static Grand.Domain.Catalog.Gallery ToEntity(this GalleryModel model)
        {
            return model.MapTo<GalleryModel, Grand.Domain.Catalog.Gallery>();
        }

        public static Grand.Domain.Catalog.Gallery ToEntity(this GalleryModel model, Grand.Domain.Catalog.Gallery destination)
        {
            return model.MapTo(destination);
        }
    }
}