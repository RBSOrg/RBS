namespace RBS.Domain
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RestaurantType> RestaurantTypes { get; set; }

    }
}
