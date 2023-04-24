using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;

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
        public async Task<ActionResult<List<Dish>>> GetDishes()
        {
            var specification = new DishWithProductsSpec();

            var dishes = await _dishRepo.GetAllWithSpecAsync(specification);

            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            var specification = new DishWithProductsSpec(id);

            return await _dishRepo.GetEntityWithSpecAsync(specification);
        }
    }
}