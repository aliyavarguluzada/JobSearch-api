namespace JobSearch.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int ReqUserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime ReqDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
