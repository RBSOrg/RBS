namespace RBS.Domain
{
    public class RestaurantType
    {
        public int RestaurantId { get; set; }
        public int TypeId { get; set; }

        public Restaurant Restaurant { get; set; }
        public Domain.Type Type { get; set; }
    }
}
