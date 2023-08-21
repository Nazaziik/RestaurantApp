using AutoMapper;
using Domain.Entities.Base;
using WebAPI.DTOs;

namespace WebAPI.Helpers
{
    public class DishUrlResolver : IValueResolver<Dish, DishToReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public DishUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Dish source, DishToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}