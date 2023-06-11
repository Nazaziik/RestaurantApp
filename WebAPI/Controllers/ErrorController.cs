using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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
                return NotFound();

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
            return BadRequest();
        }

        [HttpGet("validationerror/{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }
    }
}