namespace JobSearch.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }


    }
}
