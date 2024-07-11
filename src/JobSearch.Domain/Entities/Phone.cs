namespace JobSearch.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public string Number { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
    }
}
