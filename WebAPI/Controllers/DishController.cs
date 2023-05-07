using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IGenericRepository<Dish> _dishRepo;

        public DishController(IGenericRepository<Dish> dishRepo)
        {
            _dishRepo = dishRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<DishToReturnDTO>>> GetDishes()
        {
            var specification = new DishWithTypeAndProductsSpec();

            var dishes = await _dishRepo.GetAllWithSpecAsync(specification);

            return dishes.Select(dish => new DishToReturnDTO
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                PictureUrl = dish.PictureUrl,
                Price = dish.Price,
                TypeId = dish.TypeId,
                Type = dish.Type.Name.ToString(),
                Products = dish.Products.Select(p => p.Name).ToList()
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishToReturnDTO>> GetDish(int id)
        {
            var specification = new DishWithTypeAndProductsSpec(id);

            var dish = await _dishRepo.GetEntityWithSpecAsync(specification);

            return new DishToReturnDTO
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                PictureUrl = dish.PictureUrl,
                Price = dish.Price,
                TypeId = dish.TypeId,
                Type = dish.Type.Name.ToString(),
                Products = dish.Products.Select(p => p.Name).ToList()
            };
        }
    }
}