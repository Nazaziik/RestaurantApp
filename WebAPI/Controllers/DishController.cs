using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Specifications;
using WebAPI.DTOs;
using AutoMapper;
using WebAPI.Errors;
using Domain.Entities.Base;
using Domain.Entities.Additional;
using WebAPI.Helpers;

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
        public async Task<ActionResult<Pagination<DishToReturnDTO>>> GetDishes(
            [FromQuery] EntitySpecParams dishParams)
        {
            var specification = new DishWithTypeAndProductsSpec(dishParams);

            var countSpecification = new DishWithFiltersForCountSpec(dishParams);

            var totalItems = await _dishRepo.CountAsync(countSpecification);

            var dishes = await _dishRepo.GetAllWithMultipleSpecAsync(specification);

            var data = _mapper.Map<IReadOnlyList<Dish>, IReadOnlyList<DishToReturnDTO>>(dishes);

            return Ok(new Pagination<DishToReturnDTO>(dishParams.PageIndex, dishParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)] //Swagger improved look
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishToReturnDTO>> GetDish(int id)
        {
            var specification = new DishWithTypeAndProductsSpec(id);

            var dish = await _dishRepo.GetEntityWithSpecAsync(specification);

            if (dish == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Dish, DishToReturnDTO>(dish);
        }
    }
}