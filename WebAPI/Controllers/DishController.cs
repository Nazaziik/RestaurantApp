using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;

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
            var dishes = await _dishRepo.GetAllAsync();

            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            return await _dishRepo.GetByIdAsync(id);
        }
    }
}