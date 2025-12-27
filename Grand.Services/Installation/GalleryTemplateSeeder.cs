using Grand.Domain.Catalog;
using Grand.Domain.Data;
using System.Threading.Tasks;

namespace Grand.Services.Installation
{
    public static class GalleryTemplateSeeder
    {
        public static async Task SeedDefaultTemplate(IRepository<GalleryTemplate> repository)
        {
            if (!repository.Table.Any())
            {
                var template = new GalleryTemplate
                {
                    Name = "Default Gallery Template",
                    ViewPath = "GalleryTemplate.Default",
                    DisplayOrder = 1
                };
                await repository.InsertAsync(template);
            }
        }
    }
}