namespace RBS.Domain.CommandModels
{
    public class RestaurantBookingCommandModel
    {
        public string RId { get; set; }
        public string TId { get; set; }
        public DateTime BookDateTime { get; set; }
        public UserModel UserModel { get; set; }
    }
}
