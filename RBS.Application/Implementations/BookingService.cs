using RBS.Application.Abstractions;
using RBS.Data.Abstractions;
using RBS.Domain.CommandModels;

namespace RBS.Application.Implementations
{
    public class BookingService : IBookingService
    {
        public readonly IRestaurantRepository _restaurantRepo;
        public readonly IBookingRepository _bookingRepo;

        public BookingService(IRestaurantRepository restaurantRepo, IBookingRepository bookingRepo)
        {
            _restaurantRepo = restaurantRepo;
            _bookingRepo = bookingRepo;
        }

        public Task<string> BookRestaurant(RestaurantBookingCommandModel command)
        {
            throw new NotImplementedException();
        }
    }
}
