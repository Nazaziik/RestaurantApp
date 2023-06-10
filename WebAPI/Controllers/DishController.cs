using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using WebAPI.DTOs;
using AutoMapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IGenericRepository<Dish> _dishRepo;
        private readonly IGenericRepository<DishType> _dishTypeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public DishController(IGenericRepository<Dish> dishRepo, IGenericRepository<DishType> dishTypeRepo,
                              IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo,
                              IMapper mapper)
        {
            _dishRepo = dishRepo;
            _dishTypeRepo = dishTypeRepo;
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DishToReturnDTO>>> GetDishes()
        {
            var specification = new DishWithTypeAndProductsSpec();

            var dishes = await _dishRepo.GetAllWithMultipleSpecAsync(specification);

            return dishes.Select(dish => new DishToReturnDTO
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                PictureUrl = dish.PictureUrl,
                Price = dish.Price,
                TypeId = dish.TypeId,
                Type = dish.Type.Name.ToString(),
                Products = (dish.Products.Select(p => p.Name)).ToList()
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishToReturnDTO>> GetDish(int id)
        {
            var specification = new DishWithTypeAndProductsSpec(id);

            var dish = await _dishRepo.GetEntityWithSpecAsync(specification);

            return _mapper.Map<Dish, DishToReturnDTO>(dish);
        }
    }
}