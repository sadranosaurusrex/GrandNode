using AutoMapper;
using Grand.Domain.Catalog;
using Grand.Core.Mapper;
using Grand.Web.Areas.Admin.Models.Catalog;

namespace Grand.Web.Areas.Admin.Infrastructure.Mapper.Profiles
{
    public class GalleryTemplateProfile : Profile, IAutoMapperProfile
    {
        public GalleryTemplateProfile()
        {
            CreateMap<GalleryTemplate, GalleryTemplateModel>();
            CreateMap<GalleryTemplateModel, GalleryTemplate>()
                .ForMember(dest => dest.Id, mo => mo.Ignore());
        }

        public int Order => 0;
    }
}