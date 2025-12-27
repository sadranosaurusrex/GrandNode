using AutoMapper;
using Grand.Domain.Catalog;
using Grand.Core.Mapper;
using Grand.Web.Areas.Admin.Models.Catalog;

namespace Grand.Web.Areas.Admin.Infrastructure.Mapper.Profiles
{
    public class GalleryProfile : Profile, IAutoMapperProfile
    {
        public GalleryProfile()
        {
            CreateMap<Gallery, GalleryModel>()
                .ForMember(dest => dest.AvailableGalleryTemplates, mo => mo.Ignore());

            CreateMap<GalleryModel, Gallery>()
                .ForMember(dest => dest.Id, mo => mo.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
                .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore());
        }

        public int Order => 0;
    }
}