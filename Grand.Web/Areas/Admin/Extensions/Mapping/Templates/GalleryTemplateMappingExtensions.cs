using Grand.Core.Mapper;
using Grand.Domain.Catalog;
using Grand.Web.Areas.Admin.Models.Templates;

namespace Grand.Web.Areas.Admin.Extensions
{
    public static class GalleryTemplateMappingExtensions
    {
        public static GalleryTemplateModel ToModel(this GalleryTemplate entity)
        {
            return entity.MapTo<GalleryTemplate, GalleryTemplateModel>();
        }

        public static GalleryTemplate ToEntity(this GalleryTemplateModel model)
        {
            return model.MapTo<GalleryTemplateModel, GalleryTemplate>();
        }

        public static GalleryTemplate ToEntity(this GalleryTemplateModel model, GalleryTemplate destination)
        {
            return model.MapTo(destination);
        }
    }
}