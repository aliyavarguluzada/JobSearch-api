namespace JobSearch.Domain.Entities
{
    public class Operator : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<OperatorCode> OperatorCodes { get; set; }

    }
}
