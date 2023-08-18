using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Errors;

namespace WebAPI.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly StoreContext _context;

        public ErrorController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundError()
        {
            var response = _context.Dishes.Find(77);

            if (response == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetNServerError()
        {
            var response = _context.Dishes.Find(77);

            var answer = response.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequestError()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("validationerror/{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }
    }
}