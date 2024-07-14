namespace JobSearch.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public string Number { get; set; }
        public int OperatorCodeId { get; set; }
        public OperatorCode OperatorCode { get; set; }
    }
}
