using AutoMapper;
using Domain.Entities;
using WebAPI.DTOs;

namespace WebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Dish, DishToReturnDTO>()
                .ForMember(d => d.Type, o => o.MapFrom(d => d.Type.Name))
                .ForMember(d => d.Products, o => o.MapFrom(d => d.Products.Select(p => p.Name)))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<DishUrlResolver>());

            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(p => p.Type, o => o.MapFrom(p => p.Type.Name));
        }
    }
}