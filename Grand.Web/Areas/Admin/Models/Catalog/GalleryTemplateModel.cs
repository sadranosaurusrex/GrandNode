using Grand.Core.Models;
using Grand.Core.ModelBinding;
using Grand.Framework.Localization;
using Grand.Framework.Mapping;
using System.Collections.Generic;

namespace Grand.Web.Areas.Admin.Models.Catalog
{
    public partial class GalleryTemplateModel : BaseEntityModel, ILocalizedModel<GalleryTemplateLocalizedModel>
    {
        public GalleryTemplateModel()
        {
            Locales = new List<GalleryTemplateLocalizedModel>();
        }

        [GrandResourceDisplayName("Admin.System.Templates.Gallery.Name")]
        public string Name { get; set; }

        [GrandResourceDisplayName("Admin.System.Templates.Gallery.ViewPath")]
        public string ViewPath { get; set; }

        [GrandResourceDisplayName("Admin.System.Templates.Gallery.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<GalleryTemplateLocalizedModel> Locales { get; set; }
    }

    public partial class GalleryTemplateLocalizedModel : ILocalizedModelLocal
    {
        public string LanguageId { get; set; }

        [GrandResourceDisplayName("Admin.System.Templates.Gallery.Name")]
        public string Name { get; set; }
    }
}