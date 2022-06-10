namespace RBS.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}
