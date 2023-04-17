using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        //private readonly IGenericRepository<Dish> _dishRepo;
        private readonly IDishRepository _dishRepo;

        public DishController(IDishRepository dishRepo)
        {
            _dishRepo = dishRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dish>>> GetDishes()
        {
            //var dishes = await _dishRepo.GetAllAsync();
            var dishes = await _dishRepo.GetDishesAsync();

            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            //return await _dishRepo.GetByIdAsync(id);
            return await _dishRepo.GetDishByIdAsync(id);
        }
    }
}