using Grand.Framework.Controllers;
using Grand.Framework.Kendoui;
using Grand.Framework.Mvc.Filters;
using Grand.Framework.Security.Authorization;
using Grand.Services.Catalog;
using Grand.Services.Localization;
using Grand.Services.Logging;
using Grand.Services.Security;
using Grand.Web.Areas.Admin.Extensions.Mapping;
using Grand.Web.Areas.Admin.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Web.Areas.Admin.Controllers
{
    [PermissionAuthorize(PermissionSystemName.Products)]
    public partial class GalleryController : BaseAdminController
    {
        private readonly IGalleryService _galleryService;
        private readonly IGalleryTemplateService _galleryTemplateService;
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerActivityService _customerActivityService;

        public GalleryController(
            IGalleryService galleryService,
            IGalleryTemplateService galleryTemplateService,
            ILocalizationService localizationService,
            ICustomerActivityService customerActivityService)
        {
            _galleryService = galleryService;
            _galleryTemplateService = galleryTemplateService;
            _localizationService = localizationService;
            _customerActivityService = customerActivityService;
        }

        public IActionResult Index() => RedirectToAction("List");

        public IActionResult List()
        {
            var model = new GalleryListModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GalleryList(DataSourceRequest command, GalleryListModel model)
        {
            var galleries = await _galleryService.GetAllGalleries(
                galleryName: model.SearchGalleryName,
                pageIndex: command.Page - 1,
                pageSize: command.PageSize,
                showHidden: true);

            var gridModel = new DataSourceResult
            {
                Data = galleries.Select(x => new GalleryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Published = x.Published
                }),
                Total = galleries.TotalCount
            };

            return Json(gridModel);
        }

        public async Task<IActionResult> Create()
        {
            var model = new GalleryModel();
            await PrepareGalleryModel(model, null);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Create(GalleryModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var gallery = model.ToEntity();
                gallery.CreatedOnUtc = DateTime.UtcNow;
                gallery.UpdatedOnUtc = DateTime.UtcNow;
                await _galleryService.InsertGallery(gallery);

                await _customerActivityService.InsertActivity("AddNewGallery", gallery.Id, _localizationService.GetResource("ActivityLog.AddNewGallery"), gallery.Name);

                SuccessNotification(_localizationService.GetResource("Admin.Catalog.Galleries.Added"));
                return continueEditing ? RedirectToAction("Edit", new { id = gallery.Id }) : RedirectToAction("List");
            }

            await PrepareGalleryModel(model, null);
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var gallery = await _galleryService.GetGalleryById(id);
            if (gallery == null)
                return RedirectToAction("List");

            var model = gallery.ToModel();
            await PrepareGalleryModel(model, gallery);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public async Task<IActionResult> Edit(GalleryModel model, bool continueEditing)
        {
            var gallery = await _galleryService.GetGalleryById(model.Id);
            if (gallery == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                gallery = model.ToEntity(gallery);
                gallery.UpdatedOnUtc = DateTime.UtcNow;
                await _galleryService.UpdateGallery(gallery);

                await _customerActivityService.InsertActivity("EditGallery", gallery.Id, _localizationService.GetResource("ActivityLog.EditGallery"), gallery.Name);

                SuccessNotification(_localizationService.GetResource("Admin.Catalog.Galleries.Updated"));
                return continueEditing ? RedirectToAction("Edit", new { id = gallery.Id }) : RedirectToAction("List");
            }

            await PrepareGalleryModel(model, gallery);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var gallery = await _galleryService.GetGalleryById(id);
            if (gallery == null)
                return RedirectToAction("List");

            await _galleryService.DeleteGallery(gallery);

            await _customerActivityService.InsertActivity("DeleteGallery", gallery.Id, _localizationService.GetResource("ActivityLog.DeleteGallery"), gallery.Name);

            SuccessNotification(_localizationService.GetResource("Admin.Catalog.Galleries.Deleted"));
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(ICollection<string> selectedIds)
        {
            if (selectedIds != null)
            {
                var galleries = new List<Grand.Domain.Catalog.Gallery>();
                foreach (var id in selectedIds)
                {
                    var gallery = await _galleryService.GetGalleryById(id);
                    if (gallery != null)
                        galleries.Add(gallery);
                }
                foreach (var gallery in galleries)
                    await _galleryService.DeleteGallery(gallery);
            }

            return Json(new { Result = true });
        }

        private async Task PrepareGalleryModel(GalleryModel model, Grand.Domain.Catalog.Gallery gallery)
        {
            if (gallery != null)
            {
                model.CreatedOnUtc = gallery.CreatedOnUtc;
                model.UpdatedOnUtc = gallery.UpdatedOnUtc;
            }

            var templates = await _galleryTemplateService.GetAllGalleryTemplates();
            if (!templates.Any())
            {
                // Create default template if none exists
                var defaultTemplate = new Grand.Domain.Catalog.GalleryTemplate
                {
                    Name = "Default Gallery Template",
                    ViewPath = "GalleryTemplate.Default",
                    DisplayOrder = 1
                };
                await _galleryTemplateService.InsertGalleryTemplate(defaultTemplate);
                templates = await _galleryTemplateService.GetAllGalleryTemplates();
            }
            
            foreach (var template in templates)
            {
                model.AvailableGalleryTemplates.Add(new SelectListItem
                {
                    Text = template.Name,
                    Value = template.Id.ToString()
                });
            }
        }
    }
}