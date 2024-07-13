namespace JobSearch.Domain.Entities
{
    public class OperatorCode : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }

    }
}
