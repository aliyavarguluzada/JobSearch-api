namespace JobSearch.Domain.Entities
{
    public class Salary : BaseEntity
    {
        public string Value { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
