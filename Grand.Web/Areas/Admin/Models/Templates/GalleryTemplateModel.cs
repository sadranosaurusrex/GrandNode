using Grand.Core.Models;
using Grand.Framework.Mvc.Models;

namespace Grand.Web.Areas.Admin.Models.Templates
{
    public partial class GalleryTemplateModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string ViewPath { get; set; }
        public int DisplayOrder { get; set; }
    }
}