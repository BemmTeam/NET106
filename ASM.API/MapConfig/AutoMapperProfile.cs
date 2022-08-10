using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using AutoMapper;
using Dropbox.Api.Files;

namespace ASM.API.MapConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<CartDto, Cart>();
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, UserDto>();
            CreateMap<SendPostGetThumb, ThumbnailArg>();


        }
        
    }
}
