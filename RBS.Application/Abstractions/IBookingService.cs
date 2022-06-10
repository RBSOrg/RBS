using RBS.Domain.CommandModels;

namespace RBS.Application.Abstractions
{
    public interface IBookingService
    {
        Task<string> BookRestaurant(RestaurantBookingCommandModel command);
    }
}
