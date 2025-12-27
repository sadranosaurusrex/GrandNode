using FluentValidation;
using Grand.Core.Validators;
using Grand.Services.Localization;
using Grand.Web.Areas.Admin.Models.Catalog;
using System.Collections.Generic;

namespace Grand.Web.Areas.Admin.Validators.Catalog
{
    public class GalleryValidator : BaseGrandValidator<GalleryModel>
    {
        public GalleryValidator(
            IEnumerable<IValidatorConsumer<GalleryModel>> validators,
            ILocalizationService localizationService)
            : base(validators)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Galleries.Fields.Name.Required"));
        }
    }
}