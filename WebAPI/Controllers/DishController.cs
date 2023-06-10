using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using WebAPI.DTOs;
using AutoMapper;

namespace WebAPI.Controllers
{
    public class DishController : BaseApiController
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
        public async Task<ActionResult<IReadOnlyList<DishToReturnDTO>>> GetDishes()
        {
            var specification = new DishWithTypeAndProductsSpec();

            var dishes = await _dishRepo.GetAllWithMultipleSpecAsync(specification);

            return Ok(_mapper.Map<IReadOnlyList<Dish>, IReadOnlyList<DishToReturnDTO>>(dishes));
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