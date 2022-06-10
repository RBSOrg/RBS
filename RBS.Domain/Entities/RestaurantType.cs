namespace RBS.Domain.Entities
{
    public class RestaurantType
    {
        public int RestaurantId { get; set; }
        public int TypeId { get; set; }

        public Restaurant Restaurant { get; set; }
        public Type Type { get; set; }
    }
}
