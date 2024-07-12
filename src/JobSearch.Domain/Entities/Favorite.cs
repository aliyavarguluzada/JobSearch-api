namespace JobSearch.Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public int VacancyId { get; set; }
        public int CookieId { get; set; }
        public Vacancy Vacancy { get; set; }

    }
}
