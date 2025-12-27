using Grand.Core.Models;
using Grand.Core.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grand.Web.Areas.Admin.Models.Catalog
{
    public partial class GalleryModel : BaseEntityModel
    {
        public GalleryModel()
        {
            AvailableGalleryTemplates = new List<SelectListItem>();
        }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.Name")]
        public string Name { get; set; }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.Description")]
        public string Description { get; set; }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.GalleryTemplateId")]
        public string GalleryTemplateId { get; set; }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.Published")]
        public bool Published { get; set; }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.CreatedOnUtc")]
        public DateTime? CreatedOnUtc { get; set; }

        [GrandResourceDisplayName("Admin.Catalog.Galleries.Fields.UpdatedOnUtc")]
        public DateTime? UpdatedOnUtc { get; set; }

        public IList<SelectListItem> AvailableGalleryTemplates { get; set; }
    }
}