using Microsoft.AspNetCore.Mvc;
using RBS.API.Models;
using RBS.Application.Abstractions;
namespace RBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ApiControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("BookRestaurant")]
        public async Task<ActionResult> BookRestaurant([FromBody] BookingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            request.UserModel = UserModel;

            var command = new Domain.CommandModels.RestaurantBookingCommandModel()
            {
                RId = request.RId,
                TId = request.TId,
                BookDateTime = request.BookDateTime,
                UserModel = new Domain.UserModel()
                {
                    UserId = request.UserModel.UserId,
                    UserName = request.UserModel.UserName
                }
            };


            string bookId = await _bookingService.BookRestaurant(command);

            return Ok(bookId);
        }
    }

}