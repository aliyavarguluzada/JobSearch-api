namespace JobSearch.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int ReqUserId { get; set; } = 1;
        public bool IsDeleted { get; set; }= false;
        public bool IsActive { get; set; } = false;
        public DateTime ReqDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
