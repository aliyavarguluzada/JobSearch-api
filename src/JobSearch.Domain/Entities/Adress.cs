namespace JobSearch.Domain.Entities
{
    public class Adress : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public City City { get; set; }

    }
}
