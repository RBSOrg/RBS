namespace RBS.Domain
{
    public class UserToken
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
