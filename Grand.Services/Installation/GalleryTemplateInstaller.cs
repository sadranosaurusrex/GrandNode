using Grand.Domain.Catalog;
using Grand.Domain.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Services.Installation
{
    public static class GalleryTemplateInstaller
    {
        public static async Task InstallDefaultGalleryTemplate(IServiceProvider serviceProvider)
        {
            var galleryTemplateRepository = serviceProvider.GetRequiredService<IRepository<GalleryTemplate>>();
            
            // Check if any gallery templates exist
            if (!galleryTemplateRepository.Table.Any())
            {
                var defaultTemplate = new GalleryTemplate
                {
                    Name = "Default Gallery Template",
                    ViewPath = "GalleryTemplate.Default",
                    DisplayOrder = 1
                };
                
                await galleryTemplateRepository.InsertAsync(defaultTemplate);
            }
        }
    }
}